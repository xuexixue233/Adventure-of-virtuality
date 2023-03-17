using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public float waitTime;
    public Transform[] movePos;
    private int i;
    private float waitwaittime;
    private Transform playerDefTransform;
    // Start is called before the first frame update
    void Start()
    {
        i = 1;
        waitwaittime = waitTime;
        playerDefTransform = GameObject.FindGameObjectWithTag("player").transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePos[i].position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, movePos[i].position) < 0.1f)
        {
            if(waitTime < 0.0f)
            {
                if (i == 0)
                {
                    i = 1;
                }
                else
                {
                    i = 0;
                }
                waitTime = waitwaittime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            other.gameObject.transform.parent = gameObject.transform;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            other.gameObject.transform.parent = playerDefTransform;
        }
    }
}
