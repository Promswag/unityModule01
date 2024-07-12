using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] PlayerController player;

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, 2.5f, -3.5f);
    }

    public void SetActivePlayer(PlayerController player)
    {
        this.player = player;
    }
}
