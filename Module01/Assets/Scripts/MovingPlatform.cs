using System;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    Vector3[] waypoints;
    Vector3 prev;
    Vector3 next;
    [SerializeField] private bool loop = false;
    [SerializeField] private float speed = 1f;
    int index = 0;
    int direction = 1;
    float elapsedTime = 0f;
    float timeToWaypoint = 0f;

    void Start()
    {
        waypoints = new Vector3[transform.childCount + 1];
        waypoints[0] = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        int i = 1;
        foreach(Transform child in transform)
        {
            waypoints[i++] = new Vector3(child.position.x, child.position.y, child.position.z);
            child.gameObject.SetActive(false);
        }

        SetNextWaypoint();
    }

    void FixedUpdate()
    {
        elapsedTime += Time.deltaTime;

        float ratio = elapsedTime / timeToWaypoint;
        ratio = Mathf.SmoothStep(0, 1, ratio);
        transform.position = Vector3.Lerp(prev, next, ratio);

        if (ratio >= 1)
            SetNextWaypoint();
    }

    void SetNextWaypoint()
    {
        prev = waypoints[index];
        index = Math.Abs(index + direction) % waypoints.Length;

        if (loop) 
        {
            if (index + direction < 0)
                index = waypoints.Length - 1;
        }
        else
        {
            if (index + direction >= waypoints.Length || index + direction < 0)
                direction = -direction;
        }
        next = waypoints[index];

        elapsedTime = 0;
        float distance = Vector3.Distance(prev, next);
        timeToWaypoint = distance / speed;
    }

    void OnTriggerEnter(Collider collider)
    {
        collider.transform.SetParent(transform);
    }

    void OnTriggerExit(Collider collider)
    {
        if(collider.transform.parent == transform)
            collider.transform.SetParent(null);
    }
}
