using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Transform[] points;
    private Vector3[] pointsV;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void SetLine(Transform start, Transform end)
    {
        lineRenderer.positionCount = 2;
        this.points = new Transform[] { start, end };
    }
    public void SetLine(Vector3 start, Vector3 end)
    {
        lineRenderer.positionCount = 2;
        this.pointsV = new Vector3[] { start, end };
    }

    //private void Update()
    //{
    //    for (int i = 0; i < pointsV.Length; i++)
    //    {
    //        lineRenderer.SetPosition(i, pointsV[i]);
    //    }
    //}
}
