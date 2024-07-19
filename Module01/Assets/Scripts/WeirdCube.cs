using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
public class WeirdCube : MonoBehaviour
{
    private Vector3[] vertices;
    private Vector2[] uv;
    private int[] triangles;
    private Mesh mesh;

    void Start()
    {
        vertices = new Vector3[24];
        uv = new Vector2[24];
        triangles = new int[132];

        GenerateMeshData();
    
        mesh = new Mesh();
        mesh.name = "Cube Triangular Corners";
        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        gameObject.GetComponent<MeshCollider>().sharedMesh = mesh;
        gameObject.GetComponent<MeshCollider>().convex = true;
    }

    private void GenerateMeshData()
    {
        vertices[00] = new Vector3(0.1f, 0, 0.1f);
        vertices[01] = new Vector3(0.9f, 0, 0.1f);
        vertices[02] = new Vector3(0.9f, 0, 0.9f);
        vertices[03] = new Vector3(0.1f, 0, 0.9f);
        vertices[04] = new Vector3(0.1f, 0.1f, 0);
        vertices[05] = new Vector3(0.9f, 0.1f, 0);
        vertices[06] = new Vector3(1, 0.1f, 0.1f);
        vertices[07] = new Vector3(1, 0.1f, 0.9f);
        vertices[08] = new Vector3(0.9f, 0.1f, 1);
        vertices[09] = new Vector3(0.1f, 0.1f, 1);
        vertices[10] = new Vector3(0, 0.1f, 0.9f);
        vertices[11] = new Vector3(0, 0.1f, 0.1f);
        vertices[12] = new Vector3(0.1f, 0.9f, 0);
        vertices[13] = new Vector3(0.9f, 0.9f, 0);
        vertices[14] = new Vector3(1, 0.9f, 0.1f);
        vertices[15] = new Vector3(1, 0.9f, 0.9f);
        vertices[16] = new Vector3(0.9f, 0.9f, 1);
        vertices[17] = new Vector3(0.1f, 0.9f, 1);
        vertices[18] = new Vector3(0, 0.9f, 0.9f);
        vertices[19] = new Vector3(0, 0.9f, 0.1f);
        vertices[20] = new Vector3(0.1f, 1, 0.1f);
        vertices[21] = new Vector3(0.9f, 1, 0.1f);
        vertices[22] = new Vector3(0.9f, 1, 0.9f);
        vertices[23] = new Vector3(0.1f, 1, 0.9f);
        
        //CENTER THE MESH ON ITS AXES
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i].x -= 0.5f;
            vertices[i].y -= 0.5f;
            vertices[i].z -= 0.5f;
        }

        //CENTER RING
        triangles[0] = 4;
        triangles[1] = 12;
        triangles[2] = 13;
        
        triangles[3] = 4;
        triangles[4] = 13;
        triangles[5] = 5;
        
        triangles[6] = 5;
        triangles[7] = 13;
        triangles[8] = 14;
        
        triangles[9] = 5;
        triangles[10] = 14;
        triangles[11] = 6;
        
        triangles[12] = 6;
        triangles[13] = 14;
        triangles[14] = 15;
        
        triangles[15] = 6;
        triangles[16] = 15;
        triangles[17] = 7;
        
        triangles[18] = 7;
        triangles[19] = 15;
        triangles[20] = 16;
        
        triangles[21] = 7;
        triangles[22] = 16;
        triangles[23] = 8;
        
        triangles[24] = 8;
        triangles[25] = 16;
        triangles[26] = 17;
        
        triangles[27] = 8;
        triangles[28] = 17;
        triangles[29] = 9;
        
        triangles[30] = 9;
        triangles[31] = 17;
        triangles[32] = 18;
        
        triangles[33] = 9;
        triangles[34] = 18;
        triangles[35] = 10;
        
        triangles[36] = 10;
        triangles[37] = 18;
        triangles[38] = 19;
        
        triangles[39] = 10;
        triangles[40] = 19;
        triangles[41] = 11;
        
        triangles[42] = 11;
        triangles[43] = 19;
        triangles[44] = 12;
        
        triangles[45] = 11;
        triangles[46] = 12;
        triangles[47] = 4;

        //BOTTOM RING
        triangles[48] = 0;
        triangles[49] = 4;
        triangles[50] = 5;
        
        triangles[51] = 0;
        triangles[52] = 5;
        triangles[53] = 1;
        
        triangles[54] = 1;
        triangles[55] = 5;
        triangles[56] = 6;
        
        triangles[57] = 1;
        triangles[58] = 6;
        triangles[59] = 7;

        triangles[60] = 1;
        triangles[61] = 7;
        triangles[62] = 2;

        triangles[63] = 2;
        triangles[64] = 7;
        triangles[65] = 8;

        triangles[66] = 2;
        triangles[67] = 8;
        triangles[68] = 9;

        triangles[69] = 2;
        triangles[70] = 9;
        triangles[71] = 3;

        triangles[72] = 3;
        triangles[73] = 9;
        triangles[74] = 10;

        triangles[75] = 3;
        triangles[76] = 10;
        triangles[77] = 11;

        triangles[78] = 3;
        triangles[79] = 11;
        triangles[80] = 0;

        triangles[81] = 0;
        triangles[82] = 11;
        triangles[83] = 4;

        //TOP RING 
        triangles[84] = 12;
        triangles[85] = 20;
        triangles[86] = 21;

        triangles[87] = 12;
        triangles[88] = 21;
        triangles[89] = 13;

        triangles[90] = 13;
        triangles[91] = 21;
        triangles[92] = 14;

        triangles[93] = 14;
        triangles[94] = 21;
        triangles[95] = 22;

        triangles[96] = 14;
        triangles[97] = 22;
        triangles[98] = 15;

        triangles[99] = 15;
        triangles[100] = 22;
        triangles[101] = 16;

        triangles[102] = 16;
        triangles[103] = 22;
        triangles[104] = 23;

        triangles[105] = 16;
        triangles[106] = 23;
        triangles[107] = 17;

        triangles[108] = 17;
        triangles[109] = 23;
        triangles[110] = 18;

        triangles[111] = 18;
        triangles[112] = 23;
        triangles[113] = 20;

        triangles[114] = 18;
        triangles[115] = 20;
        triangles[116] = 19;

        triangles[117] = 19;
        triangles[118] = 20;
        triangles[119] = 12;

        // BOTTOM & TOP FACES
        triangles[120] = 20;
        triangles[121] = 23;
        triangles[122] = 22;

        triangles[123] = 20;
        triangles[124] = 22;
        triangles[125] = 21;

        triangles[126] = 0;
        triangles[127] = 1;
        triangles[128] = 2;

        triangles[129] = 0;
        triangles[130] = 2;
        triangles[131] = 3;
    }
}
