using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPattern1_StaticMagic : MonoBehaviour {

    private Transform magicianPos;

    private Vector2 dir;
    private Vector2 magicVelocity;

    public GameObject effect;
    public float speed;

	// Use this for initialization
	void Start () {
        magicianPos = GameObject.FindGameObjectWithTag("MagicianBoss").transform;

        dir = transform.position - magicianPos.position;
        magicVelocity = dir.normalized * speed;

        Destroy(gameObject, 4f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(magicVelocity * Time.fixedDeltaTime);
		
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
