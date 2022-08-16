using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    public float speed;


    private float rotate = 0;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(rotate == 360)
        {
            rotate = 0;
        }
        rotate = rotate + 200 * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, rotate);
        transform.Translate(0, speed * Time.deltaTime, 0);
        
    }
}
