using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour {
    public int health = 1;

    public GameObject deadEffect;
    private float attackBtwTime;
    public float startAttackTime;
    public bool readyToAttack = false;
    // Use this for initialization
    void Start()
    {
        attackBtwTime = startAttackTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(deadEffect, transform.position, Quaternion.identity);
        }
        if (attackBtwTime <= 0)
        {
            readyToAttack = true;
        }
        else
        {
            attackBtwTime -= Time.deltaTime;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (other.CompareTag("Player") && readyToAttack == true)
        {

            player.health--;
            attackBtwTime = startAttackTime;
            readyToAttack = false;
            Debug.Log("Hit!");
        }


    }
}
