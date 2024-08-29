using UnityEngine;

public class ButtonOpenDoor : MonoBehaviour
{
    [SerializeField] GameObject[] doors;
    [SerializeField] bool copyColorOnTrigger;

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.name);
        Debug.Log(name);
        if (gameObject.layer == 0 || SceneController.instance.GetMatchingLayer(gameObject.layer) == collider.gameObject.layer)
        {
            foreach(GameObject door in doors)
            {
                if (door.gameObject.layer == 0 || SceneController.instance.GetMatchingLayer(door.gameObject.layer) == collider.gameObject.layer)
                    door.SetActive(false);
                Debug.Log(collider.name);
                Debug.Log(name);
            }
            if (copyColorOnTrigger)
            {
                Material material = collider.GetComponent<MeshRenderer>().sharedMaterial;
                foreach(MeshRenderer meshRenderer in transform.parent.GetComponentsInChildren<MeshRenderer>())
                {
                    meshRenderer.material = material;
                    meshRenderer.gameObject.layer = SceneController.instance.GetKeyFromValue(collider.gameObject.layer);
                }

            }
            gameObject.SetActive(false);
        }
    }
}
