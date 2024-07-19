using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshCollider))]
[RequireComponent(typeof(MeshFilter))]
public class TeleporterMesh : MonoBehaviour
{
    private Vector3[] vertices;
    private Vector2[] uv;
    private int[] triangles;
    private Mesh mesh;

    void Start()
    {
        vertices = new Vector3[8];
        uv = new Vector2[8];
        triangles = new int[36];

        GenerateMeshData();
    
        mesh = new Mesh();
        mesh.name = "Teleporter Pad";
        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
		mesh.RecalculateBounds();
		mesh.RecalculateNormals();
		mesh.RecalculateTangents();
		mesh.RecalculateUVDistributionMetrics();

        gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
        gameObject.GetComponent<MeshCollider>().convex = true;
		gameObject.GetComponent<MeshFilter>().sharedMesh = mesh;
    }

    private void GenerateMeshData()
    {
        vertices[00] = new Vector3(0, 0, 0);
        vertices[01] = new Vector3(1, 0, 0);
        vertices[02] = new Vector3(1, 0, 1);
        vertices[03] = new Vector3(0, 0, 1);
        vertices[04] = new Vector3(0.2f, 0.1f, 0.2f);
        vertices[05] = new Vector3(0.8f, 0.1f, 0.2f);
        vertices[06] = new Vector3(0.8f, 0.1f, 0.8f);
        vertices[07] = new Vector3(0.2f, 0.1f, 0.8f);
        
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i].x -= 0.5f;
            vertices[i].y -= 0.5f;
            vertices[i].z -= 0.5f;
        }

        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(1, 0);
        uv[2] = new Vector2(1, 1);
        uv[3] = new Vector2(0, 1);
        uv[4] = new Vector2(0.2f, 0.2f);
        uv[5] = new Vector2(0.8f, 0.2f);
        uv[6] = new Vector2(0.8f, 0.8f);
        uv[7] = new Vector2(0.2f, 0.8f);

        triangles[0] = 0;
        triangles[1] = 4;
        triangles[2] = 5;
        
        triangles[3] = 0;
        triangles[4] = 5;
        triangles[5] = 1;
        
        triangles[6] = 1;
        triangles[7] = 5;
        triangles[8] = 6;
        
        triangles[9] = 1;
        triangles[10] = 6;
        triangles[11] = 2;
        
        triangles[12] = 2;
        triangles[13] = 6;
        triangles[14] = 7;
        
        triangles[15] = 2;
        triangles[16] = 7;
        triangles[17] = 3;
        
        triangles[18] = 3;
        triangles[19] = 7;
        triangles[20] = 4;
        
        triangles[21] = 3;
        triangles[22] = 4;
        triangles[23] = 0;
        
        triangles[24] = 4;
        triangles[25] = 7;
        triangles[26] = 6;
        
        triangles[27] = 4;
        triangles[28] = 6;
        triangles[29] = 5;
        
        triangles[30] = 0;
        triangles[31] = 2;
        triangles[32] = 3;
        
        triangles[33] = 0;
        triangles[34] = 1;
        triangles[35] = 2;
    }
}
