using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayer : MonoBehaviour {
    private GameObject player;
    private SpriteRenderer renderer;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        renderer = GetComponent<SpriteRenderer>();
		
	}

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y <= transform.position.y)
        {
            renderer.sortingOrder = 30;
        }
        else if(player.transform.position.y > transform.position.y)
        {
            renderer.sortingOrder = 200;
        }
    }
}
