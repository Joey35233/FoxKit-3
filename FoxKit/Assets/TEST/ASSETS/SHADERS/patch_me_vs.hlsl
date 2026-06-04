#	define REGISTERMAP(_type, _name, _register) cbuffer c##_type : _register { _type _name; }

#define ToVPos(vpos) (vpos + PIXELCENTEROFFSET)
#define ToVPos4 ToVPos

#define TFetch(_texture, _sampler, _uv) 		_texture.Sample(_sampler, _uv)
#define TFetchOffset(_texture, _sampler, _uv, _offset) 		_texture.Sample(_sampler, _uv, _offset)

#define TFetch1D 								TFetch
#define TFetch1DOffset							TFetchOffset
#define TFetch2D 								TFetch
#define TFetch2DOffset							TFetchOffset
#define TFetch2DGrad							TFetchGrad
#define TFetch2DProj(_texture, _sampler, _uv) 	TFetch(_texture, _sampler, CalcProjectCoords(_uv))

#define TFetch3D 								TFetch
#define TFetchCube 								TFetch
#define TFetchCubeBias(_texture, _sampler, _uv) _texture.SampleBias(_sampler, (_uv).xyz, (_uv).w)


#line 326 "..\Gr\Dg\shader\shader.h"
#define TFetchGrad(_texture, _sampler, _uv, _dx, _dy) _texture.SampleGrad(_sampler, _uv, _dx, _dy)
#define TFetch2DLod(_texture, _sampler, _uv) 	_texture.SampleLevel(_sampler, (_uv).xy, (_uv).w)
#define TFetchCubeLod(_texture, _sampler, _uv)	_texture.SampleLevel(_sampler, (_uv).xyz, (_uv).w)

#line 331 "..\Gr\Dg\shader\shader.h"

float TFetch2DProjCmp(Texture2D _texture, SamplerComparisonState _sampler, float4 _uv){
	float3 prjectionUV = (_uv.xyz/_uv.w );
	return _texture.SampleCmp(_sampler, prjectionUV.xy, prjectionUV.z);
}

void vs_main(

	 in	float4	inPosition	: POSITION,
	 out	float4	outPosition	: OUT_POSITION
)
{
}