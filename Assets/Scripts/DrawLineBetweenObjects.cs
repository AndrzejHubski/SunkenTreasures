using System.Collections.Generic;
using UnityEngine;

public class DrawLineBetweenObjects : MonoBehaviour
{
    public LineRenderer lineRenderer;  
    public List<Transform> points;

    void Start()
    {
        
        lineRenderer.positionCount = points.Count;

       
        for (int i = 0; i < points.Count; i++)
        {
            lineRenderer.SetPosition(i, points[i].position);
        }
    }

    void Update()
    {
        for (int i = 0; i < points.Count; i++)
        {
            lineRenderer.SetPosition(i, points[i].position);
        }
    }
}
