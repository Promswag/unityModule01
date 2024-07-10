using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    void Start()
    {
        
    }

    void Update()
    {
        if (player)
            transform.position = player.transform.position + new Vector3(2, 2, -2);
    }
}
