using UnityEngine;

namespace Fox.Gr
{
    public enum TerrainTileType
    {
        TRE2 = 0,
        HTRE = 1,
    }

    public class TerrainMapAsset : ScriptableObject
    {
        TerrainTileType Type;

        TerrainTileLocatorControl LocatorControl;

        TerrainTileDataControl DataControl;

        TerrainTileMatMapControl MatMapControl;
    }
}