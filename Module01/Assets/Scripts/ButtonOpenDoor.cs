using System.Xml.Serialization;
using UnityEditor.AssetImporters;
using UnityEditor.PackageManager.Requests;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOpenDoor : MonoBehaviour
{
    [SerializeField] GameObject[] doors;
    [SerializeField] bool copyColorOnTrigger;

    void OnTriggerEnter(Collider collider)
    {
        if (gameObject.layer == 0 || SceneController.instance.GetMatchingLayer(gameObject.layer) == collider.gameObject.layer)
        {
            foreach(GameObject door in doors)
            {
                if (door.gameObject.layer == 0 || SceneController.instance.GetMatchingLayer(door.gameObject.layer) == collider.gameObject.layer)
                    door.SetActive(false);
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
