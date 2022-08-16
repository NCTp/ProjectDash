using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Magician : MonoBehaviour {
    private Transform playerPos;
    private Vector3 magicianScale;
    private Animator anim;
    public bool isDetected = false;
    private bool isIdle = true;
    private bool isCasting = false;
    private bool isSummonning = false;
    private Player player;
    public bool lookRight;
    public GameObject center;
    public Slider healthBar;

    private float speed;
    private float castRate;
    private float timeAfterCast;
    private Enemy enemy;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        enemy = GetComponent<Enemy>();
        anim = GetComponent<Animator>();
        anim.SetTrigger("Spawn");
        healthBar.gameObject.SetActive(true);
        /*
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        health = GetComponent<Enemy>().health;
        
        anim.SetTrigger("Run");
        lookRight = true;

        timeAfterCast = 0;
        castRate = 1f;
        */

    }


    void Update()
    {
        if(enemy.health <= 0)
        {
            player.bossKill++;
            Instantiate(center, center.transform.position, Quaternion.identity);
        }
        /*

        if (playerPos.position.x < transform.position.x && lookRight
            || playerPos.position.x > transform.position.x && !lookRight)
        {
            lookRight = !lookRight;

            magicianScale = transform.localScale;
            magicianScale.x *= -1;
            transform.localScale = magicianScale;
        }
        */
        healthBar.value = enemy.health;

    }
}




