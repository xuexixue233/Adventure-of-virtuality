using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStone : Enemy
{
    public float speed;
    public float waitTime;
    public float radius;
    public Transform[] movePos;
    private int i = 0;
    private bool movingRight = true;
    private float wait;
    private Vector2 playp;
    private Transform playerTransform;
    // Start is called before the first frame update
    public new void Start()
    {
        base.Start();
        wait=waitTime;
        playerTransform = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
    }

    // Update is called once per frame
    public new void Update()
    {
        base.Update();
        if (playerTransform != null)
        {
            float distance = (transform.position - playerTransform.position).sqrMagnitude;
            if (distance < radius)
            {
                playp.x = playerTransform.position.x;
                playp.y = transform.position.y;
                transform.position = Vector2.MoveTowards(transform.position,
                                                         playp,
                                                         speed * Time.deltaTime);
                //surpriseObject.SetActive(true);
                //Invoke("dissurprise", surpisedTime);
            }
            else
            {
        transform.position = Vector2.MoveTowards(transform.position, movePos[i].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, movePos[i].position) < 10f)
        {
            if (waitTime <= 0)
            {
                if (movingRight)
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    movingRight = false;
                }
                else
                {

                    transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRight = true;
                }
                if (i == 0)
                {
                    i = 1;
                }
                else
                {
                    i = 0;
                }
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
}
