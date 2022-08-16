using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFB : MonoBehaviour {
    public float timer;
    public GameObject finalBoss;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(timer <= 0)
        {
            Instantiate(finalBoss, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            timer -= Time.deltaTime;
        }
		
	}
}
