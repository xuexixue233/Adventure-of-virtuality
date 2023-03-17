using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class enemyAntiman : Enemy
{
    public GameObject attack;
    public float speed;
    public float waitTime;
    public float radius;
    public float attackTime;
    public float attack1Time;
    public float delayTime;
    public float nextTime;
    public float attackRadius;
    public GameObject surprise;
    public int sUpon;
    public float surpriseTime;
    public Transform[] movePos;
    private int i = 0;
    private bool isSurprised = false;
    private bool hasSurprise = false;
    private bool AntiAttack = false;
    private bool isFirstTurn = true;
    private bool antiTurn = false;
    private bool antiTurnl = false;
    private bool antiTurnr = false;
    private float wait;
    private float atime;
    private float delay;
    private float delayTime1;
    private float a1time;
    private float nTime;
    private bool isFirstAttack=true;
    private Animator antiAnim;
    private Vector2 playp;
    private Transform playerTransform;
    // Start is called before the first frame update
    public new void Start()
    {
        base.Start();
        transform.eulerAngles = new Vector3(0, 180, 0);
        wait = waitTime;
        atime = attackTime;
        a1time = attack1Time;
        nTime = nextTime;
        delay = delayTime;
        delayTime1 = delayTime;
        antiAnim = GetComponent<Animator>();
        playerTransform = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
    }

    // Update is called once per frame
    public new void Update()
    {
        base.Update();
        if (playerTransform != null&&AntiAttack==false&&antiTurn==false)
        {
            float distance = (transform.position - playerTransform.position).sqrMagnitude;
            if (distance < attackRadius)
            {
                AntiAttack = true;
            }
            if (distance < radius&& AntiAttack == false && antiTurn == false)
            {
                if (isSurprised&&hasSurprise==false)
                {
                    Vector2 surprisePos = new Vector2(transform.position.x, transform.position.y + sUpon);
                    GameObject sur= Instantiate(surprise, surprisePos, Quaternion.identity)as GameObject;
                    sur.transform.parent = gameObject.transform;
                    isSurprised = false;
                    hasSurprise = true;
                    StartCoroutine(destroySurprise(sur));
                }
                antiAnim.SetBool("look", false);
                playp.x = playerTransform.position.x;
                playp.y = transform.position.y;
                antitoTurn();
                //surpriseObject.SetActive(true);
                //Invoke("dissurprise", surpisedTime);
            }
            else if(AntiAttack == false && antiTurn == false)
            {
                isFirstAttack = true;
                isSurprised = true;
                if (movePos[i].position.x<transform.position.x||(i==0&& movePos[i].position.x == transform.position.x))
                {
                            transform.eulerAngles = new Vector3(0, 180, 0);
                }
                else
                {

                            transform.eulerAngles = new Vector3(0, 0, 0);
                }
                transform.position = Vector2.MoveTowards(transform.position, movePos[i].position, speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, movePos[i].position) < 0.1f)
                {
                    antiAnim.SetBool("look", true);
                    if (waitTime <= 0)
                    {
                        if (i == 0)
                        {
                            i = 1;
                        }
                        else
                        {
                            i = 0;
                        }
                        
                        waitTime = atime;
                    }
                    else
                    {
                        waitTime -= Time.deltaTime;
                    }
                }
                else
                {
                    antiAnim.SetBool("look", false);
                }

            }

        }
        
        if (AntiAttack == true && antiTurn == false)
        {
            antiAnim.SetBool("attack", true);
            if (isFirstAttack)
            {
            }
            else
            {
                if (attack1Time <= 0)
                {
                   attack1Time = a1time;
                
                }
                else
                {
                   attack1Time -= Time.deltaTime;
                } 
                
            }
            isFirstAttack = false;
            if (nextTime <= 0)
            {
                disAttack();
                nextTime = nTime;
            }
            else
            {
                nextTime -= Time.deltaTime;
            }
        }
        
        if (attackTime <= 0)
        {
                attackTime = atime;
                
        }
        else
        {
                attackTime -= Time.deltaTime;
        }

    }
    IEnumerator destroySurprise(GameObject gb)
    {
        yield return new WaitForSeconds(surpriseTime);
        Destroy(gb);
        hasSurprise = false;
    }
    void disAttack()
    {
        antiAnim.SetBool("attack", false);
        AntiAttack = false;
    }
    IEnumerator TurnLeft()
    {
        yield return new WaitForSeconds(delayTime);
        transform.eulerAngles = new Vector3(0, 180, 0);
        antiAnim.SetBool("look", false);
        antiTurnr = false;
        transform.position = Vector2.MoveTowards(transform.position, playp, speed * Time.deltaTime);
        antiTurn = false;
    }
    IEnumerator TurnRight()
    {
        yield return new WaitForSeconds(delayTime);
        transform.eulerAngles = new Vector3(0, 0, 0);
        antiAnim.SetBool("look", false);
        antiTurnl = false;
        transform.position = Vector2.MoveTowards(transform.position, playp, speed * Time.deltaTime);
        antiTurn = false;
    }
    void antitoTurn()
    {
        if (isFirstTurn==false)
        {
            if (playp.x < transform.position.x)
            {
                antiTurnl = true;
                if (antiTurnr)
                {
                    antiTurn = true;
                    antiAnim.SetBool("look", true);
                    StartCoroutine(TurnLeft());
                }
                else
                {
                    transform.position = Vector2.MoveTowards(transform.position, playp, speed * Time.deltaTime);
                }
            }
            else
            {
                antiTurnr = true;
                if (antiTurnl)
                {
                    antiTurn = true;
                    antiAnim.SetBool("look", true);
                    StartCoroutine(TurnRight());
                }
                else
                {
                    transform.position = Vector2.MoveTowards(transform.position, playp, speed * Time.deltaTime);
                }
            }

        }
        else
        {
            antiTurn = false;
            if (playp.x < transform.position.x)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            isFirstTurn = false;
        }
    }
    void enemyAttack1()
    {
        attack.GetComponent<PolygonCollider2D>().enabled = true;
        SoundManager.playFistClip();
        Invoke("disAttack1", 0.15f);
    }
    void disAttack1()
    {
        attack.GetComponent<PolygonCollider2D>().enabled = false;
    }
}
