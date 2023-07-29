using UnityEngine;

namespace FoxKit.TEST
{
    public static class DgUtils
    {
        public static Mesh FullscreenMesh;
        public static Mesh FullscreenMeshWithUVs;

        public static void Init()
        {
            FullscreenMesh = new Mesh
            {
                vertices = new Vector3[]
                {
                    new Vector3(0, 0, 0),
                    new Vector3(2, 0, 0),
                    new Vector3(0, 2, 0),
                },
                triangles = new int[] { 0, 1, 2 },
            };

            FullscreenMeshWithUVs = new Mesh
            {
                vertices = new Vector3[]
                {
                    new Vector3(0, 0, 0),
                    new Vector3(2, 0, 0),
                    new Vector3(0, 2, 0),
                },
                triangles = new int[] { 0, 1, 2 },
                uv = new Vector2[]
                {
                    new Vector2(0, 0),
                    new Vector2(2, 0),
                    new Vector2(0, 2),
                },
            };
        }
    }
}