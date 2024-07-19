using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    private Vector3[] vertices = new Vector3[12];
    private Vector2[] uv = new Vector2[12];
    private int[] triangles = new int[60];
    private GameObject meshObject;
    private Mesh mesh;

    void Start()
    {
        GenerateMeshData();

        mesh = new Mesh();
        mesh.name = "Custom Mesh";

        meshObject = new GameObject("Generated Object", typeof(MeshRenderer), typeof(MeshFilter), typeof(MeshCollider));
        meshObject.GetComponent<MeshCollider>().material = Resources.Load("No Friction Material", typeof(PhysicMaterial)) as PhysicMaterial;
        meshObject.GetComponent<MeshCollider>().sharedMesh = mesh;
        meshObject.GetComponent<MeshFilter>().mesh = mesh;
        meshObject.transform.position = new Vector3(6f, 1.5f, 0f);

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }

    private void GenerateMeshData()
    {
        vertices[00] = new Vector3(0, 0, 0);
        vertices[01] = new Vector3(0, 1, 0);
        vertices[02] = new Vector3(1, 1, 0);
        vertices[03] = new Vector3(1, 0.9f, 0);
        vertices[04] = new Vector3(0.1f, 0.9f, 0);
        vertices[05] = new Vector3(0.1f, 0, 0);
        vertices[06] = new Vector3(0, 0, 1);
        vertices[07] = new Vector3(0, 1, 1);
        vertices[08] = new Vector3(1, 1, 1);
        vertices[09] = new Vector3(1, 0.9f, 1);
        vertices[10] = new Vector3(0.1f, 0.9f, 1);
        vertices[11] = new Vector3(0.1f, 0, 1);
        
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i].x -= 0.5f;
            vertices[i].y -= 0.5f;
            vertices[i].z -= 0.5f;
        }

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 4;
        
        triangles[3] = 0;
        triangles[4] = 4;
        triangles[5] = 5;
        
        triangles[6] = 1;
        triangles[7] = 2;
        triangles[8] = 4;
        
        triangles[9] = 2;
        triangles[10] = 3;
        triangles[11] = 4;
        
        triangles[12] = 6;
        triangles[13] = 10;
        triangles[14] = 7;
        
        triangles[15] = 6;
        triangles[16] = 11;
        triangles[17] = 10;
        
        triangles[18] = 10;
        triangles[19] = 9;
        triangles[20] = 8;
        
        triangles[21] = 10;
        triangles[22] = 8;
        triangles[23] = 7;
        
        triangles[24] = 0;
        triangles[25] = 6;
        triangles[26] = 7;
        
        triangles[27] = 0;
        triangles[28] = 7;
        triangles[29] = 1;
        
        triangles[30] = 0;
        triangles[31] = 5;
        triangles[32] = 11;
        
        triangles[33] = 0;
        triangles[34] = 11;
        triangles[35] = 6;
        
        triangles[36] = 1;
        triangles[37] = 7;
        triangles[38] = 8;
        
        triangles[39] = 1;
        triangles[40] = 8;
        triangles[41] = 2;
        
        triangles[42] = 3;
        triangles[43] = 2;
        triangles[44] = 8;
        
        triangles[45] = 3;
        triangles[46] = 8;
        triangles[47] = 9;
        
        triangles[48] = 5;
        triangles[49] = 4;
        triangles[50] = 10;
        
        triangles[51] = 5;
        triangles[52] = 10;
        triangles[53] = 11;
        
        triangles[54] = 4;
        triangles[55] = 3;
        triangles[56] = 9;
        
        triangles[57] = 4;
        triangles[58] = 9;
        triangles[59] = 10;
    }
}
