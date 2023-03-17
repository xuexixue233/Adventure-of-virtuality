using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class alphaTextChange : MonoBehaviour
{
    public float waittime = 0;
    public float time = 1.0f;
    public float timer = 0;
    private float alpha = 0.0f;
    private bool workingstatus = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (workingstatus && PlayerHealth.isDie)
        {
            timer += Time.deltaTime;
            if (timer > waittime && alpha <= 1)
            {
                alpha = (timer - waittime) / time;

                gameObject.GetComponent<Text>().color = new Color(gameObject.GetComponent<Text>().color.r, gameObject.GetComponent<Text>().color.g, gameObject.GetComponent<Text>().color.b, alpha);
            }
            if (timer > waittime + time)
            {
                workingstatus = false;
            }
        }
    }
}