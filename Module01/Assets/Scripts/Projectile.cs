using UnityEngine;

public class Projectile : MonoBehaviour
{

    public void Init(Vector3 direction, float speed, int layer, Material material)
    {
        GetComponent<Rigidbody>().velocity = direction * speed;
        GetComponent<MeshRenderer>().material = material;
        gameObject.layer = layer;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == SceneController.instance.GetMatchingLayer(gameObject.layer))
        {
            collision.transform.GetComponent<PlayerController>().Die();
        }
        Destroy(gameObject);
    }
}
