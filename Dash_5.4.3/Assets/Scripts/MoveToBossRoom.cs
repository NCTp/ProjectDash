using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToBossRoom : MonoBehaviour {
    public Transform bossRoomPos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.position = bossRoomPos.position;
    }
}
