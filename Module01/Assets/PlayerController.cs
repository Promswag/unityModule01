// using System;
// using System.Collections;
using System.Collections.Generic;
// using System.IO.Pipes;
// using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController cc;
    public Dictionary<string, GameObject> players;
    // GameObject active;

    // public Dictionary<string, playerStats>

    void Start()
    {
        // KeyCode key = KeyCode.Alpha1;
        GameObject[] go = GameObject.FindGameObjectsWithTag("Player");
        Debug.Log(go);
        foreach(GameObject player in go) {
            Debug.Log(player);
            // players.Add(player.name, player);
        }
        Debug.Log(players);
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
        // foreach((KeyCode k, GameObject go) in players)
        // {
        //     if (Input.GetKeyDown(k))
        //     {
        //         active = players[k];
        //     }
        // }
        // Debug.Log(active);
        // velocity += gravity * Time.deltaTime;
        // Vector3 move = new Vector3(Input.GetAxis("Horizontal"), velocity, Input.GetAxis("Vertical"));

        // cc.Move(move * (Time.deltaTime * speed));
        // if (cc.isGrounded) {
        //     velocity = 0;
        //     if (Input.GetKeyDown(KeyCode.Space)) {
        //         velocity = Mathf.Sqrt(jumpForce * -2f * gravity);
        //     }
        // }
    }

    // void OnTriggerEnter(Collider other) {
    //     if (other.isTrigger) {
    //         Debug.Log("Game Over");
    //         Destroy(gameObject);
    //     }
    // }
}
