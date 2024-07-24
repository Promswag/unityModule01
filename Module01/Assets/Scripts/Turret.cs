using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField, Range(0, 2)] private float firingSpeed;
    [SerializeField, Range(0, 2)] private float projectileSpeed;
    [SerializeField] private float offset;
    Transform spawn;
    [SerializeField] Projectile projectilePrefab;
    [SerializeField] Material material;

    private float elapsedTime = 0;

    void Start()
    {
        foreach(Transform child in transform)
        {
            if (child.name == "Spawn")
                spawn = child;
        }
        if (!spawn)
        {
            Debug.Log(gameObject + "has no spawn!");
        }
        transform.parent.GetComponent<MeshRenderer>().material = material;
        foreach (Transform child in transform)
        {
            MeshRenderer tmp = child.GetComponent<MeshRenderer>();
            if (tmp)
                tmp.material = material;
        }
        foreach (Transform child in transform.parent)
        {
            MeshRenderer tmp = child.GetComponent<MeshRenderer>();
            if (tmp)
                tmp.material = material;
        }
        elapsedTime += offset;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= 1f / firingSpeed)
        {
            elapsedTime = 0f;
            Instantiate(projectilePrefab, spawn.position, Quaternion.identity).Init(spawn.transform.forward, projectileSpeed, gameObject.layer, material);
        }
    }

}
