using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMagician : MonoBehaviour {

    private GameObject magician;
    private Enemy health;

	// Use this for initialization
	void Start () {
        magician = GameObject.FindGameObjectWithTag("MagicianBoss");
        health = magician.GetComponent<Enemy>();

		
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = magician.transform.position;
        if(health.health <=0)
        {
            Destroy(gameObject);
        }
        
		
	}
}
