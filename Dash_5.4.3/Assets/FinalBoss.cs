using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour {
    private Animator anim;
    public int health = 1;
    private bool isLeft = true;
    private Transform playerPos;

    private float attackBtwTime;
    public float startAttackTime;
    public bool readyToAttack = false;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        anim.SetTrigger("Spawn");
        attackBtwTime = startAttackTime;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            anim.SetTrigger("Dead");
        }
        if (attackBtwTime <= 0)
        {
            readyToAttack = true;
        }
        else
        {
            attackBtwTime -= Time.deltaTime;
        }

        if (transform.position.x < playerPos.position.x && isLeft == true)
        {
            Flip();
        }
        else if (transform.position.x >= playerPos.position.x && isLeft == false)
        {
            Flip();
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
    void Flip()
    {
        isLeft = !isLeft;
        Vector3 knightScale = transform.localScale;
        knightScale.x *= -1;
        transform.localScale = knightScale;
    }
}
