using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour {
    private LineRenderer lineRenderer;
    public Transform playerPos;
    private GameObject decoy;

	// Use this for initialization
	void Start () {
        lineRenderer = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        
        if(decoy == null)
        {
            decoy = FindObjectOfType<Decoy>().gameObject;
        }
        else
        {
            lineRenderer.SetPosition(0, playerPos.position);
            lineRenderer.SetPosition(1, decoy.transform.position);
        }
        
        
        
        
        
	}
}
