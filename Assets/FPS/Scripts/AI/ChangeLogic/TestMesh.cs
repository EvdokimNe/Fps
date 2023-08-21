using UnityEngine;

namespace FPS.Scripts.Game.ChangeLogic
{
    public class TestMesh : MonoBehaviour
    {
        public float scaleFactor = 1.1f;

        public MeshFilter mesh;


        void Update()
        {
            Vector3[] vertices = mesh.mesh.vertices;

            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i] *= scaleFactor;
                if (vertices[i].y < 1)
                {
                    ;
                }
            }

            mesh.mesh.vertices = vertices;
            mesh.mesh.RecalculateNormals();
            mesh.mesh.RecalculateBounds();
        }
    }
}