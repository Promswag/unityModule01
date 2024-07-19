using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(LineRenderer))]
public class TeleporterArches : MonoBehaviour
{
    LineRenderer lineRenderer;
    [SerializeField] int steps;
    [SerializeField] float radius;
    [SerializeField] float thickness;
    [SerializeField] float heightOffset;
    [SerializeField] float yScale;
    [SerializeField] float xScale;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.loop = true;
        lineRenderer.startWidth = thickness;
        lineRenderer.endWidth = thickness;
        Draw();
    }

    void Update()
    {
        lineRenderer.startWidth = thickness;
        lineRenderer.endWidth = thickness;
        lineRenderer.loop = true;
        Draw();
    }

    void Draw()
    {
        lineRenderer.positionCount = steps * 4;

        for (int i = 0; i < steps; i++)
        {
            float circumferenceProgress =  i / (steps * 2.0f);
            float radian = circumferenceProgress * 2 * Mathf.PI;

            float x = xScale * radius * Mathf.Cos(radian);
            float y = yScale * radius * Mathf.Sin(radian);

            // if (i < steps / 2 - limit || i > steps / 2 + limit)
            // {
                lineRenderer.SetPosition(i, new Vector3(x, y + heightOffset, -0.3f));
                lineRenderer.SetPosition(i + steps, new Vector3(-0.3f, y + heightOffset, -x));
                lineRenderer.SetPosition(i + steps * 2, new Vector3(-x, y + heightOffset, 0.3f));
                lineRenderer.SetPosition(i + steps * 3, new Vector3(0.3f, y + heightOffset, x));
            // }
        }
    }
}
