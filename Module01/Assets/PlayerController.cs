using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isActive = false;
    private readonly KeyCode[] keys = {KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3};
    private readonly string[] players = {"Claire", "John", "Thomas"};
    private CharacterController cc;

    [SerializeField] private float verticalVelocity = -1.0f;
    [SerializeField] private float horizontalVelocity = 0.0f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float jumpForce = 1.0f;

    void SwitchActivePlayer(int key)
    {
        if (players[key] == name) {
            isActive = true;
            GameObject.FindObjectOfType<CameraController>().SetActivePlayer(this);
        }
        else {
            isActive = false;
        }
    }

    void Start()
    {
        cc = GetComponent<CharacterController>();
        cc.detectCollisions = false;
        SwitchActivePlayer(0);
    }

    void Update()
    {
        foreach (KeyCode key in keys) {
            if (Input.GetKeyDown(key)) {
                SwitchActivePlayer((int)key - 49);
            }
        }


        if (!cc.isGrounded) {
            verticalVelocity += gravity * Time.deltaTime;
        }


        if (isActive) {
            horizontalVelocity = Input.GetAxis("Horizontal");
            Vector3 move = new Vector3(horizontalVelocity, verticalVelocity, 0);
            cc.Move(move * (Time.deltaTime * speed));
        }
        else {
            horizontalVelocity *= 0.95f;
            if (Mathf.Abs(horizontalVelocity) < 0.1)
                horizontalVelocity = 0;
            Vector3 move = new Vector3(horizontalVelocity, verticalVelocity, 0);
            cc.Move(move * (Time.deltaTime * speed));
        }

        if (cc.isGrounded) {
            verticalVelocity = 0f;
        }

        if (verticalVelocity == 0f) {
            if (Input.GetKeyDown(KeyCode.Space) && isActive) {
                verticalVelocity = Mathf.Sqrt(jumpForce * -2f * gravity);
            }
        }
    }
}
