using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {
    private Player player;
    public GameObject openedDoor;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        
		if(player.bossKill == 2)
        {
            Destroy(gameObject);
            Instantiate(openedDoor, transform.position, Quaternion.identity);
        }
	}
}
