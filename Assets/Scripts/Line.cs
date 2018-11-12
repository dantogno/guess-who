using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField]
    private Transform endpoint0;
    [SerializeField]
    private Transform endpoint1;
    private LineRenderer lineRenderer;

	// Use this for initialization
	void Start ()
    {
        lineRenderer = GetComponent<LineRenderer>();
 
	}

    private void Update()
    {
        lineRenderer.SetPosition(0, endpoint0.position);
        lineRenderer.SetPosition(1, endpoint1.position);
    }

}
