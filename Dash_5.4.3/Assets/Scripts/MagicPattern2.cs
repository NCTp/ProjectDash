using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPattern2 : MonoBehaviour {
    
    public GameObject magicPrefab;

    private float spawnAfterCast;
    private float timeAfterCast;
    public float spawnRate;
    public float castRate;

    // Use this for initialization
    void Start () {

        timeAfterCast = 0;
        spawnAfterCast = 0;
    }
	
	// Update is called once per frame
	void Update () {
        spawnAfterCast += Time.deltaTime;

        if (spawnAfterCast >= spawnRate)
        {
            timeAfterCast += Time.deltaTime;

            if (timeAfterCast >= castRate)
            {
                timeAfterCast = 0;

                Instantiate(magicPrefab, transform.position, Quaternion.identity);

                spawnAfterCast = 0;
            }
            
        }
    }
}
