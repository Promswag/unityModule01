using UnityEngine;

public class DeathVolume : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        collider.transform.GetComponent<PlayerController>().Die();
    }
}
