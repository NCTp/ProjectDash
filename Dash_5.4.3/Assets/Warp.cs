using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour {

    private Transform warpPoint;
    private GameObject player;
	// Use this for initialization
	void Start () {
        warpPoint = GameObject.FindGameObjectWithTag("Center").transform;
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        player.transform.position = warpPoint.position;
    }
}
