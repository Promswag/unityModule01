using UnityEngine;

public class OverlapTrigger : MonoBehaviour
{
    int count = 0;
    static Material green;
    static Material red;
    MeshRenderer meshRenderer;

    void Awake()
    {
        green = Resources.Load("Materials/Green", typeof(Material)) as Material;
        red = Resources.Load("Materials/Red", typeof(Material)) as Material;
    }

    void Start()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == gameObject.layer)
        {
            count++;
            if (count == 4)
            {
                meshRenderer.material = green;
                SceneController.instance.PlayerAtExit(collider.gameObject.name, 1);
            }
        }

    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.layer == gameObject.layer)
        {
            count--;
            meshRenderer.material = red;
            SceneController.instance.PlayerAtExit(collider.gameObject.name, 0);
        }
    }
}
