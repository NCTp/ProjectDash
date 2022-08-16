using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    
    public float speed;
    public GameObject destroyEffect;
    public float lifeTime;

    private Transform playerPos;

    // Use this for initialization
    void Start () {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        Invoke("DestroyProjectile", lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
	}

    void DestroyProjectile()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if(other.CompareTag("Player"))
        {
            player.health--;
        }
        DestroyProjectile();
    }

}
