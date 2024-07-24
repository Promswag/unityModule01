using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private readonly KeyCode[] keys = {KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3};
	private readonly string[] players = {"Claire", "John", "Thomas"};

	private Rigidbody rigidBody;

	private bool isActive = false;
	private bool isJumping = false;
	private bool isGrounded = true;
	private float horizontalVelocity = 0f;

	[SerializeField] private float speed = 0f;
	[SerializeField] private float jumpForce = 0f;

	void Start()
	{
		SceneController.instance.AddPlayer(name);
		rigidBody = GetComponent<Rigidbody>();
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
			horizontalVelocity *= 0.99f;
			if (Mathf.Abs(horizontalVelocity) < 0.1f)
			{
				horizontalVelocity = 0f;
			}
		}

		if (isJumping == false) 
		{
			if (Input.GetKeyDown(KeyCode.Space) && isActive && isGrounded)
			{
				isJumping = true;
				isGrounded = false;
				StartCoroutine(JumpDelay());
				rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
			}
		}

		Vector3 move = transform.TransformDirection(new Vector3(horizontalVelocity, rigidBody.velocity.y, 0f));
		rigidBody.velocity = new Vector3(move.x, rigidBody.velocity.y, 0f);
	}

	void SwitchActivePlayer(int key)
	{
		if (players[key] == name) 
		{
			isActive = true;
			CameraController.instance.SetTarget(this.transform);
			Debug.Log(name + " selected!");
		}
		else 
		{
			isActive = false;
		}
	}

	void OnCollisionStay(Collision collision)
	{
		foreach (ContactPoint contact in collision.contacts)
		{
			if (contact.normal == Vector3.up)
			{
				isGrounded = true;
			}
		}
	}

	void OnCollisionExit(Collision collision)
	{
		isGrounded = false;
	}

	IEnumerator JumpDelay()
	{
		yield return new WaitForSeconds(0.1f);
		isJumping = false;
	}

	public void Die()
	{
		CameraController.instance.Reset();
		Debug.Log(gameObject.name + " has died!");
		Destroy(gameObject);
		SceneController.instance.GameOver();
	}
}
