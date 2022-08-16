using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicianAnim : MonoBehaviour {

    private Transform playerPos;
    private Vector3 magicianScale;

    public bool lookLeft;
    
    private Animator anim;

    public GameObject magicPrefab;

    public float speed;
    private float castRate;
    private float timeAfterCast;

    void Start () {
        anim = GetComponent<Animator>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

        lookLeft = true;

        timeAfterCast = 0;
        castRate = 1f;
    }


    void Update()
    {
        if(Vector2.Distance(transform.position, playerPos.position) < 2)
        {
            if (Vector2.Distance(transform.position, playerPos.position) > 1.5)
            {
                anim.SetBool("isFollowing", true);
                anim.SetBool("isCasting", false);

                speed = 0.3f;

                transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
            }
            else
            {
                anim.SetBool("isCasting", true);


                timeAfterCast += Time.deltaTime;


                if (timeAfterCast >= castRate)

                {
                    timeAfterCast = 0;

                    // 마법 생성                     

                    Instantiate(magicPrefab, transform.position, Quaternion.identity);

                    SoundManager.PlaySound("Fire1");
                }
            }
        }
        
        if (playerPos.position.x > transform.position.x && lookLeft
            || playerPos.position.x < transform.position.x && !lookLeft)
        {
            lookLeft = !lookLeft;

            magicianScale = transform.localScale;
            magicianScale.x *= -1;
            transform.localScale = magicianScale;
        }
        

    }
}
