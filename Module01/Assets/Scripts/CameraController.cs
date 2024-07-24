using UnityEngine;

public class CameraController : MonoBehaviour
{
    static public CameraController instance;
    Transform target;

    void Awake()
    {
        if (instance != null)
            return;
        instance = this;
        target = transform;
    }

    void Update()
    {
        transform.position = new Vector3(target.position.x, 2.5f, -3.5f);
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    public void Reset()
    {
        target = transform;
    }
}
