using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Knight : MonoBehaviour {
    private Transform playerPos;
    private bool isLeft = true;
    private Animator anim;
    private Player player;
    private Enemy enemy;
    private float timer;
    public float startTimer;
    public GameObject center;
    public Slider healthBar;
    public int health = 5;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        anim.SetTrigger("Spawn");
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        enemy = GetComponent<Enemy>();
        timer = startTimer;
        healthBar.gameObject.SetActive(true);


    }
	
	// Update is called once per frame
	void Update () {
        if(transform.position.x < playerPos.position.x && isLeft == true)
        {
            Flip();
        }
        else if(transform.position.x >= playerPos.position.x && isLeft == false)
        {
            Flip();
        }

        
        if (health <= 0)
        {
            player.bossKill++;
            Instantiate(center, center.transform.position, Quaternion.identity);
            healthBar.gameObject.SetActive(false);
            
            
        }
        healthBar.value = health;
        

        
        
		
	}
    void Flip()
    {
        isLeft = !isLeft;
        Vector3 knightScale = transform.localScale;
        knightScale.x *= -1;
        transform.localScale = knightScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.collider.GetComponent<Player>();
        if (collision.collider.CompareTag("Player"))
        {
            player.health--;
        }
    }

    
    private void OnTriggerStay2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (other.CompareTag("Player"))
        {
            if(timer <= 0)
            {
                player.health--;
                timer = startTimer;
            }
            else
            {
                timer -= Time.deltaTime;
            }
            
        }
    }
}
