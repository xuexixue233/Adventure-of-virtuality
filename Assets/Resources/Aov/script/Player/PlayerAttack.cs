using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float stopTime;
    public Rigidbody2D rb2d;
    private float numA = 1;
    private Animator anim;
    private bool isattack = false;
    private new PolygonCollider2D collider2D;
    private PlayerInputActions controls;

    //void Awake()
    //{
    //    controls = new PlayerInputActions();
    //    controls.GamePlay.Attack.started += ctx => Attack();

    //}
    //void OnEnable()
    //{
    //    controls.GamePlay.Enable();
    //}
    //void OnDisable()
    //{
    //    controls.GamePlay.Disable();
    //}
    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("player").GetComponent<Animator>();
        collider2D = GetComponent<PolygonCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHealth.isDie == false)
        {
            Attack();

        }

    }
    void Attack()
    {
    if (GameController.isGameAlive == true && GameController.isGameSaying == false && GameController.isSkilling == false)
    {
            //if (anim.GetCurrentAnimatorStateInfo(0).IsName("attack"))
            //{
            //    isattack = true;
            //}
            //else
            //{
            //    StartCoroutine(disableDoubleAttack());
            //}
            if (Input.GetButtonDown("Attack") || Input.GetMouseButtonDown(0))
            {
                if (anim.GetCurrentAnimatorStateInfo(0).IsName("attack"))
                //if (isattack)
                {
                    numA++;
                    //Time.timeScale = timeSpeed;
                    anim.SetFloat("numattack", numA);
                    isattack = true;
                    //{
                    //    numA++;
                    //    if (numA > 3)
                    //    {
                    //        numA = 1;
                    //    }
                    //    anim.SetFloat("numattack", numA);
                    //    SoundManager.playFanClip();
                    //    GameController.isGameAlive = false;
                    //    isattack = true;
                    //    StartCoroutine(disableattack());
                    //    StartCoroutine(StartAttack());
                    //}


                }
                else if (anim.GetCurrentAnimatorStateInfo(0).IsName("attack2"))
                //if (isattack)
                {
                    numA++;
                    //Time.timeScale = timeSpeed;
                    anim.SetFloat("numattack", numA);
                    isattack = true;
                    //{
                    //    numA++;
                    //    if (numA > 3)
                    //    {
                    //        numA = 1;
                    //    }
                    //    anim.SetFloat("numattack", numA);
                    //    SoundManager.playFanClip();
                    //    GameController.isGameAlive = false;
                    //    isattack = true;
                    //    StartCoroutine(disableattack());
                    //    StartCoroutine(StartAttack());
                    //}


                }
                else if (anim.GetCurrentAnimatorStateInfo(0).IsName("attack3"))
                //if (isattack)
                {
                    numA=1;
                    //Time.timeScale = timeSpeed;
                    anim.SetFloat("numattack", numA);
                    isattack = true;
                    //{
                    //    numA++;
                    //    if (numA > 3)
                    //    {
                    //        numA = 1;
                    //    }
                    //    anim.SetFloat("numattack", numA);
                    //    SoundManager.playFanClip();
                    //    GameController.isGameAlive = false;
                    //    isattack = true;
                    //    StartCoroutine(disableattack());
                    //    StartCoroutine(StartAttack());
                    //}


                }
                else
                {
                    numA = 1;
                    //Time.timeScale = timeSpeed;
                    anim.SetFloat("numattack", numA);
                    isattack = true;

                }

            }
            else
            {
                anim.SetFloat("numattack", 0);
            }
        }
        if (isattack)
        {
            GameController.isGameAlive = false;
            rb2d.velocity = new Vector2(0, 0);
            rb2d.bodyType = RigidbodyType2D.Static;
            StartCoroutine(stopattack());
        }
        else
        {
            rb2d.bodyType = RigidbodyType2D.Dynamic;

        }
    }
    //IEnumerator disableHitBox()
    //{
    //    yield return new WaitForSeconds(time);
        
    //    //collider2D.enabled = false;

    //    StartCoroutine(disableattack());
    //}
    IEnumerator stopattack()
    {
        yield return new WaitForSeconds(stopTime);
        //Time.timeScale = 1.0f;
        isattack = false;
        GameController.isGameAlive = true;
        //GameController.isGameAlive = true;
    }
    
}
