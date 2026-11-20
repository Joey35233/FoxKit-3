# Handedness TODO (Fox -> Unity)

Fox is right-handed; we convert with `(-x, y, z)`. With mirrored meshes, the Unity view matrix
(Z row negated) and a positive-X projection, object, world and view space are all X-mirrors of
Fox's and clip space is identical. Dot products and matrix * vector need nothing. The items below
are what the mirror does show through in. None of this has been tested in Unity yet.

File:line references are Fox source lines, i.e. the `#line` numbers in the shader dumps.

## 1. Cross products

- Every `cross(` (58 sites) returns the negated result in a mirrored space. Today that flips every
  binormal (normal-map green inverted), e.g. `fox3ddf_blin_ic_lym_4mt_dirty_vr_vs.hlsl:43,51`.
- Fix once in `UnityPatch/PreHLSL.hlsl`; leave `tangent.w` as imported:

  ```hlsl
  float3 UnityPatch_CrossRaw(float3 a, float3 b) { return cross(a, b); }
  float3 UnityPatch_Cross(float3 a, float3 b) { return cross(b, a); }
  #define cross UnityPatch_Cross
  ```

- Exception: quaternion rotation. `Prim_Poly_SpecLit.shdr:137-138` and
  `Primitive_Liquid2Final.shdr:91-93` must keep the original cross, because `FoxToUnityQuaternion`
  already carries the sign. Have the patcher rewrite those four `cross(` to `UnityPatch_CrossRaw`.
  Both quaternions arrive per vertex (`inAttribute1`) and need converting in the particle stream.
- `FoxToUnityQuaternion` can be `new(q.x, -q.y, -q.z, q.w)`: same rotation, but it keeps the
  quaternion's sign (matters between animation keys) and skips the angle-axis round trip.

## 2. Cubemaps

- Cube lookups are by world direction, and our world directions have x negated, so an unconverted
  cubemap is sampled mirrored.
- Bake it at import: swap the +X and -X faces and flip each face horizontally.
- Do not apply the upside-down render-target convention to them; a direction lookup has no V.
- With that, `TFetchCube`, `TFetchCubeBias` and `TFetchCubeLod` need no patch (see 6).

## 3. Terrain

- Vertices are built from UVs: `position = (u, height, v) * m_localParam[1].xyz + m_localParam[2].xyz`
  (`NewTerrain.shdr:255`, `NewTerrain_Decal.shdr:204`).
- Mirror by negating `m_localParam[1].x` and `m_localParam[2].x`.
- The normals come from bare crosses (`NewTerrain.shdr:288,296`, `NewTerrain_Decal.shdr:231-260`)
  and are then correct with the cross swap from 1. Without it they point down.

## 4. SH matrices

- `SH_SphereMap_Common.shdr:92-104` evaluates `c * M * c` with `c = (-n.x, -n.z, n.y, 1)` for each
  matrix in `g_psParamSH` and `g_psParamSHSky`.
- For matrices taken from Fox data: negate row 0 and column 0 (element [0][0] keeps its sign).
- Matrices we compute ourselves from Unity-space lighting only need to follow that `c` layout.

## 5. Other inputs and hard-coded axes

- Convert directions and matrices, not just positions: light and wind vectors
  (`fox3ddf_fast_wave.shdr:125-131`), shadow and decal projections, clone instance matrices, bones.
- World XZ used as texture coordinates with a hard-coded scale. Tiling patterns are fine as is;
  maps anchored to world geometry need u negated or the texture mirrored at import:
  - `Primitive_Tpp24hOcean.shdr:416` water depth map (anchored), `:326` (tiling)
  - `Primitive_TppFourierOcean.shdr:67,191`, `DR_TonemapRainFilter.shdr:319`,
    `tpp3dfw_star.shdr:47`, `Prim_TppSkyCld3.shdr:70,75`
  - terrain world texture, `GetWorldTexLodParam` at `NewTerrain.shdr:291`
  - None of these has been reviewed one by one.

## 6. TFetch patch

- Nothing calls the generic `TFetch(` directly, so leave `TFetch`, `TFetchOffset`, `TFetch1D` and
  the three cube macros as Fox wrote them and patch only the 2D entry points.
- Helper in `PreHLSL.hlsl`:

  ```hlsl
  float2 UnityPatch_FlipV(float2 uv) { return float2(uv.x, 1 - uv.y); }
  ```

- Replace each `#define` by macro name (not as one block, which depends on `#line 326` and exact
  whitespace):
  - `TFetch2D(_t, _s, _uv)` -> `TFetch(_t, _s, UnityPatch_FlipV(_uv))`
  - `TFetch2DOffset(_t, _s, _uv, _o)` -> `TFetchOffset(_t, _s, UnityPatch_FlipV(_uv), (_o) * int2(1, -1))`
  - `TFetch2DProj` -> call `TFetch2D` instead of `TFetch`
  - `TFetchGrad`, `TFetch2DLod` -> wrap the coordinate in `UnityPatch_FlipV`; for `TFetchGrad`
    also negate the y of `_dx` and `_dy`
  - `TFetch2DProjCmp` -> wrap `prjectionUV.xy` in `UnityPatch_FlipV`
- Bugs in the current patch: `1 - y` on cube directions is not a flip; texel offsets keep their y
  sign (`CopyReductionX4.shdr:15-18`).
- `TFetch3D`: flip only if every 3D texture is row-flipped like the 2D ones (the fog volume is a
  render target, so it is).

## 7. Render-target flip and NGetFaceSign

- `outPosition.y *= -1` (`PostEntryPoint.hlsl`) is the only winding flip in the pipeline; the
  mirror itself does not change winding. It affects culling and `SV_IsFrontFace`
  (`NGetFaceSign`, `fox3ddf_blin.shdr:1003-1013`).
- What Unity appears to do, from its docs and forum reports, not confirmed in source:
  - The flip is a property of the render target. `GraphicsState.invertProjection` is documented
    as set when the render texture was created with `RenderTextureCreationFlags.AllowVerticalFlip`.
  - The `RenderTextureDescriptor(width, height, ...)` constructors set that flag; the default
    constructor does not. `GrPluginDeferredGeometry` uses the former.
  - For such targets Unity assumes the shader output is flipped and reverses the cull winding to
    match. People drawing unflipped geometry into a render texture report needing
    `SetInvertCulling(true)`.
- Unknown: whether Unity reverses the front-face winding (then `SV_IsFrontFace` already agrees
  with Fox) or swaps the cull mode (then `NGetFaceSign` is inverted and needs a patch).
- Test: draw a two-sided material that outputs `NGetFaceSign` as colour, into a target with and
  without `AllowVerticalFlip`, and into the back buffer in a player build.
