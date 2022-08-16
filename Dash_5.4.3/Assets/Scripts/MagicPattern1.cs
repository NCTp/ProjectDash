using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPattern1 : MonoBehaviour {

    Transform playerPos;
    Transform magicianPos;
    Transform target1Pos;
    Transform target2Pos;
    Transform target3Pos;
    Transform target4Pos;

    public GameObject magicPrefab;

    private float timeAfterCast;
    public float castRate;


	// Use this for initialization
	void Start () {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        magicianPos = GameObject.FindGameObjectWithTag("MagicianBoss").transform;
        target1Pos = GameObject.FindGameObjectWithTag("Target1").transform;
        target2Pos = GameObject.FindGameObjectWithTag("Target2").transform;
        target3Pos = GameObject.FindGameObjectWithTag("Target3").transform;
        target4Pos = GameObject.FindGameObjectWithTag("Target4").transform;

        timeAfterCast = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {

        timeAfterCast += Time.deltaTime;
        
        if (timeAfterCast >= castRate)
        {
            timeAfterCast = 0;

            // 마법 생성
            //Instantiate(magicPrefab, target1Pos.position, Quaternion.identity);
            //Instantiate(magicPrefab, target2Pos.position, Quaternion.identity);
            //Instantiate(magicPrefab, target3Pos.position, Quaternion.identity);
            //Instantiate(magicPrefab, target4Pos.position, Quaternion.identity);
            Instantiate(magicPrefab, transform.position, Quaternion.identity);

            //SoundManager.MagicSound("fire1");
        }
    }
}



