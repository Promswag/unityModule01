using UnityEngine;

public class MeshCombine : MonoBehaviour
{
    MeshFilter meshFilter;
    MeshRenderer meshRenderer;
    MeshCollider meshCollider;


    void Start()
    {

        Mesh mesh = new Mesh();

        MeshFilter[] meshes = GetComponentsInChildren<MeshFilter>();

        int verticeLength = 0;
        int uvsLength = 0;
        int trianglesLength = 0;

        for (int i = 0; i < meshes.Length; i++)
        {
            verticeLength += meshes[i].mesh.vertices.Length;
            uvsLength += meshes[i].mesh.uv.Length;
            trianglesLength += meshes[i].mesh.triangles.Length;
        }

        Vector3[] vertices = new Vector3[verticeLength];
        Vector2[] uvs = new Vector2[uvsLength];
        int[] triangles = new int[trianglesLength];

        int j = 0;
        int k = 0;
        int l = 0;
        Debug.Log("LENGTGH           " + meshes.Length);
        foreach (MeshFilter m in meshes)
        {
            int offset = j;
            foreach (Vector3 v in m.mesh.vertices)
                vertices[j++] = new Vector3(v.x * m.transform.localScale.x + m.transform.position.x, v.y * m.transform.localScale.y + m.transform.position.y, v.z * m.transform.localScale.z + m.transform.position.z);
            foreach (Vector2 u in m.mesh.uv) 
                uvs[k++] = u;
            foreach (int t in m.mesh.triangles) 
                triangles[l++] = t + offset;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        mesh.RecalculateTangents();

        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;
        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material = Resources.Load("Materials/White", typeof(Material)) as Material;
        meshCollider = gameObject.AddComponent<MeshCollider>();
        meshCollider.sharedMesh = mesh;
        meshCollider.material = Resources.Load("Materials/No Friction Material", typeof(PhysicMaterial)) as PhysicMaterial;
    }
}
