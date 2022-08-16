using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float speed;
    public float dashPower;
    Vector2 moveInput;
    Vector2 moveVelocity;
    Vector2 dashVelocity;
    Vector2 decoyPosition;
    public GameObject decoy;
    public GameObject dashEffect;
    public GameObject dashEffect2;
    public LineRenderer lineRenderer;
    public int health;
    private int dashTime = 3;
    public int dashCoolTime = 3;
    private float time;
    

    private Enemy enemyInfo;
    private Rigidbody2D rb;
    private bool isReadyToDash;
    private GameObject decoys;
    private GameObject effect2;
    private Vector2 attackDir;
    private Animator anim;
    private bool facingRight= true;
    private bool facingUp = false;
    private bool facingDown = false;
    private float fireDistance = 50f;
    private GameObject target;
    private bool isRightWalk = false;
    RaycastHit2D[] hitInfos;
    private TrailRenderer trailRenderer;
    private GameManager gm;
    public int bossKill=0;
    public Image[] images;
    public Image[] dashes;


    // Use this for initialization
    void Start () {
        //PlayerPrefs.DeleteAll();
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        transform.position = gm.lastCheckPointPos;

        rb = GetComponent<Rigidbody2D>();
        isReadyToDash = true;
        anim = GetComponent<Animator>();
        lineRenderer.enabled = false;
        trailRenderer = GetComponentInChildren<TrailRenderer>();
        
	}
	
	// Update is called once per frame
	void Update () {
        // 동작 제어
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxis("Vertical"));
        moveVelocity = moveInput.normalized * speed;
        dashVelocity = moveInput.normalized * dashPower;
        
        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            moveVelocity *= 0.5f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isReadyToDash == true && dashTime >0)
        {
            decoyPosition = transform.position;
            decoys = Instantiate(decoy, decoyPosition, Quaternion.identity);
            rb.AddForce(dashVelocity);
            Instantiate(dashEffect,transform.position, Quaternion.identity);
            effect2 = Instantiate(dashEffect2, transform.position, Quaternion.identity);
            isReadyToDash = false;
            lineRenderer.enabled = true;
            dashTime--;
            
            StartCoroutine("Trail");

            SoundManager.PlaySound("Dash");
        }
        
        else if(Input.GetKeyDown(KeyCode.Space)&& isReadyToDash ==false)
        {
            
            isReadyToDash = true;
            lineRenderer.enabled = false;
            
            decoys.transform.position = Vector2.MoveTowards(decoys.transform.position, transform.position, 25f * Time.deltaTime);
            Destroy(decoys, 0.1f);
            Destroy(effect2, 0.1f);
            
            hitInfos = Physics2D.RaycastAll(transform.position, attackDir, fireDistance);
            
            for(int i =0; i<hitInfos.Length; i++)
            {
                RaycastHit2D hit = hitInfos[i];
                Enemy target = hit.collider.GetComponent<Enemy>();

                if(target != null)
                {
                    target.health--;
                    Instantiate(dashEffect, target.transform.position, Quaternion.identity);
                }
                FinalBoss finalBoss = hit.collider.GetComponent<FinalBoss>();
                if (finalBoss != null)
                {
                    finalBoss.health--;
                    Instantiate(dashEffect, target.transform.position, Quaternion.identity);
                }
                Knight knight = hit.collider.GetComponent<Knight>();
                if(knight != null)
                {
                    knight.health--;
                    Instantiate(dashEffect, target.transform.position, Quaternion.identity);

                }
            


            }

            SoundManager.PlaySound("Attack");

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
        if (health > 0)
        {
            // 체력조절
            for (int k = 0; k < health; k++)
            {
                images[k].gameObject.SetActive(true);
            }
            for (int j = health; j < 5; j++)
            {
                images[j].gameObject.SetActive(false);
            }
        }
        
        if (health <= 0)
        {
            Destroy(gameObject);
            images[0].gameObject.SetActive(false);
            images[1].gameObject.SetActive(false);
            Instantiate(dashEffect, transform.position, Quaternion.identity);
            GameManager.instance.PlayerDead();

            if (decoys != null)
            {
                Destroy(decoys);

            }
        }
        if (dashTime < 3 && Time.time > time + dashCoolTime)
        {
            dashTime++;
            time = Time.time;
        }
        
        if (dashTime > 0)
        {
            // 대쉬 갯수 표기
            for (int m = 0; m < dashTime; m++)
            {
                dashes[m].gameObject.SetActive(true);
            }
            for (int n = dashTime; n < 3; n++)
            {
                dashes[n].gameObject.SetActive(false);
            }
        }
        else
        {
            dashes[0].gameObject.SetActive(false);
        }
        
        // 애니메이션 제어
        anim.SetBool("RightWalk", isRightWalk);
        anim.SetBool("FacingRight", facingRight);
        anim.SetBool("FacingUp", facingUp);
        anim.SetBool("FacingDown", facingDown);

        if (moveInput.x != 0)
        {
            isRightWalk = true;
        }
        else if(moveInput.x == 0)
        {
            isRightWalk = false;
        }
        if(moveInput.y >0)
        {
            
            facingUp = true;
            facingDown = false;
        }
        else if(moveInput.y==0)
        {
            
            facingUp = false;
            facingDown = false;
        }
        else if(moveInput.y <0)
        {
            facingUp = false;
            facingDown = true;
        }
        
        
        target = GameObject.FindGameObjectWithTag("Decoy");
        
        if(target != null)
        {
            // 레이캐스트 확인용
            attackDir = target.transform.position - transform.position;
            Debug.DrawRay(transform.position, attackDir, Color.red);
        }
        if (facingRight == false && moveInput.x > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput.x < 0)
        {
            Flip();
        }
        
    }


    void Flip()
    {
        // 스프라이트를 뒤집는 매서드
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    
    private void FixedUpdate()
    {

        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

    }
    IEnumerator Trail()
    {
        trailRenderer.enabled = true;
        yield return new WaitForSeconds(0.5f);
        trailRenderer.enabled = false;
    }

}
