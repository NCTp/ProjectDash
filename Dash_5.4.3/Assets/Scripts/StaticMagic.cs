using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticMagic : MonoBehaviour
{

    private Transform playerPos;
    private Vector2 dir;
    private Vector2 magicVelocity;

    public float speed;
    public GameObject effect;

    void Start()
    {

        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

        dir = playerPos.position - transform.position;
        magicVelocity = dir.normalized * speed;

        Destroy(gameObject, 2f);
    }

    void FixedUpdate()
    {
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
