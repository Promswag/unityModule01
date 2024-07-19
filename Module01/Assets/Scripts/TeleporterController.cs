using System.Collections;
using UnityEngine;

public class TeleporterController : MonoBehaviour
{
    [SerializeField] Transform target;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == gameObject.layer)
        {
            StartCoroutine(Teleport(collider));
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.layer == gameObject.layer)
        {
            StopAllCoroutines();
        }
    }

    IEnumerator Teleport(Collider collider)
    {
        yield return new WaitForSeconds(2f);
        collider.transform.position = new Vector3(target.position.x, target.position.y, target.position.z);
    }
}
