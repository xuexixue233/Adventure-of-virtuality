using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySmartCoil : Enemy
{
    public float waitTime;
    public float radius;
    public float Speed;
    public float backSpeed;
    public Transform movePos;
    public Transform leftDownPos;
    public Transform rightUpPos;
    //public Transform fatherPos;
    private Rigidbody2D coiltran;
    private float wait;
    //private Vector2 coilp;
    //private Vector3 mainp;
    private PlayerHealth playerhit;
    //public float surpisedTime;
    //public GameObject surpriseObject;
    private Transform playerTransform;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        playerhit = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerHealth>();
        wait = waitTime;
        movePos.position = GetRandomPos();
        coiltran = GetComponent<Rigidbody2D>();
        //coilp = transform.position;
        //mainp = new Vector2(fatherPos.position.x+transform.position.x,fatherPos.position.y+transform.position.y);
        playerTransform = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
        //surpriseObject = GameObject.FindGameObjectWithTag("surprise");
        //surpriseObject.SetActive(false);

    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        if (playerTransform != null)
        {
            float distance = (transform.position - playerTransform.position).sqrMagnitude;
            if (distance < radius)
            {
                transform.position = Vector2.MoveTowards(transform.position,
                                                         playerTransform.position,
                                                         Speed * Time.deltaTime);

                //coiltran.MovePosition(transform.position + new Vector3(playerTransform.position.x / playerTransform.position.y, 1, 0) * Speed / 2 * Time.deltaTime);

                //surpriseObject.SetActive(true);
                //Invoke("dissurprise", surpisedTime);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, movePos.position, Speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, movePos.position) < 10f)
                {
                    if (waitTime <= 0)
                    {
                        movePos.position = GetRandomPos();
                        waitTime = wait;
                    }
                    else
                    {
                        waitTime -= Time.deltaTime;
                    }
                }

            }
        }
    }
    Vector2 GetRandomPos()
    {
        Vector2 rndPos = new Vector2(Random.Range(leftDownPos.position.x, rightUpPos.position.x), Random.Range(leftDownPos.position.y, rightUpPos.position.y));
        return rndPos;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("Attack") || other.gameObject.CompareTag("playerAttack1") || other.gameObject.CompareTag("playerAttack2") || other.gameObject.CompareTag("playerAttack3")) && other.GetType().ToString() == "UnityEngine.PolygonCollider2D")
        {

            transform.position = Vector2.MoveTowards(transform.position,
                                                     playerTransform.position,
                                                     -backSpeed * Time.deltaTime);
        }
        if (other.gameObject.CompareTag("missile"))
        {

            transform.position = Vector2.MoveTowards(transform.position,
                                                     other.transform.position,
                                                     -backSpeed/2 * Time.deltaTime);
        }
        if (other.gameObject.CompareTag("player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            if (playerhit != null && GameController.isGameSaying == false && PlayerHealth.isDie == false)
            {
                playerhit.DamagePlayer(damage);
            }else
            {

                transform.position = Vector2.MoveTowards(transform.position,
                                                         playerTransform.position,
                                                         -backSpeed * Time.deltaTime);
            }
        }
    }
    //void dissurprise()
    //{
    //    surpriseObject.SetActive(false);
    //}
}
