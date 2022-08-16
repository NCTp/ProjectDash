using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAnim : MonoBehaviour {

    private Transform playerPos;
    private Vector3 slimeScale;

    public float speed;
    private Animator anim;

    public bool lookLeft;
   

	void Start () {
        anim = GetComponent<Animator>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

        lookLeft = true;
	}

    void Update() {

        if (Vector2.Distance(transform.position, playerPos.position) < 2)
        {
            if (Vector2.Distance(transform.position, playerPos.position) > 0.4)
            {
                anim.SetBool("isFollowing", true);
                anim.SetBool("isFast", false);

                transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
            }
            else
            {
                anim.SetBool("isFast", true);

                transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * 2 * Time.deltaTime);
            }
        }
        else
        {
            anim.SetBool("isFollowing", false);
        }

        if (playerPos.position.x > transform.position.x && lookLeft || playerPos.position.x < transform.position.x && !lookLeft)
        {
            lookLeft = !lookLeft;

            slimeScale = transform.localScale;
            slimeScale.x *= -1;
            transform.localScale = slimeScale;
        }                
    }
}
