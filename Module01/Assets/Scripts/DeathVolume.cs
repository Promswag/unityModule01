using UnityEngine;

public class DeathVolume : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.name);
        Debug.Log(name);
        collider.transform.GetComponent<PlayerController>().Die();
    }
}
