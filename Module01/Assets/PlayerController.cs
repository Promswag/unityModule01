using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private readonly KeyCode[] keys = {KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3};
    private readonly string[] players = {"Claire", "John", "Thomas"};

    private bool isActive = false;
    private float horizontalVelocity = 0f;

    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private Transform feet;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Collider _collider;
    [Space]
    [SerializeField] private float speed = 0f;
    [SerializeField] private float jumpForce = 0f;

    [SerializeField] private Vector3 boxOffset;
    [SerializeField] private float castDistance = 0f;

    void SwitchActivePlayer(int key)
    {
        if (players[key] == name) 
        {
            isActive = true;
            FindObjectOfType<CameraController>().SetActivePlayer(this);
            Debug.Log(name + " selected!");
        }
        else 
        {
            isActive = false;
        }
    }

    void Update()
    {
        foreach (KeyCode key in keys)
        {
            if (Input.GetKeyDown(key))
            {
                SwitchActivePlayer((int)key - 49);
            }
        }

        if (isActive)
        {
            horizontalVelocity = Input.GetAxis("Horizontal") * speed;
        }
        else
        {
            horizontalVelocity *= 0.90f;
            if (Mathf.Abs(horizontalVelocity) < 0.1f)
            {
                horizontalVelocity = 0f;
            }
        }

        Vector3 move = transform.TransformDirection(new Vector3(horizontalVelocity, rigidBody.velocity.y, 0f));
        rigidBody.velocity = new Vector3(move.x, rigidBody.velocity.y, 0f);

        // RaycastHit hit;

            if (Input.GetKeyDown(KeyCode.Space) && isActive)
            {
                // RaycastHit hitInfo;
                if(Physics.BoxCast(transform.position, transform.localScale * 0.5f, -transform.up, out RaycastHit hitInfo, transform.rotation, castDistance))
                {
                    Debug.Log("Grounded");
                    rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                }
                Debug.Log(hitInfo.collider.name);
            }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

            Gizmos.DrawRay(transform.position, -transform.up * castDistance);
            Gizmos.DrawWireCube(transform.position + -transform.up * castDistance, transform.localScale);
    }

}
