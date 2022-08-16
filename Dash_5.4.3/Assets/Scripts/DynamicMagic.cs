using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicMagic : MonoBehaviour {

    public float speed;

    private GameObject effect;
    private Transform playerPos;

	void Start () {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

        Destroy(gameObject, 5f);
	}
	
	void FixedUpdate () {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.fixedDeltaTime);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (other.CompareTag("Player"))
        {
            player.health--;
            Instantiate(effect, transform.position, Quaternion.identity);
            Destroy(gameObject);

            Debug.Log("Hit!");
        }
    }
}
