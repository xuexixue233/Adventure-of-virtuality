
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class alphaChange : MonoBehaviour
{
    public float waittime = 0;
    public float time = 1.0f;
    public float timer = 0;
    public float finAlpha = 1;
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
            if (timer > waittime&&alpha<=finAlpha)
            {
                alpha = (timer - waittime) / time;

                gameObject.GetComponent<Image>().color = new Color(gameObject.GetComponent<Image>().color.r, gameObject.GetComponent<Image>().color.g, gameObject.GetComponent<Image>().color.b, alpha);
            }
            if (timer > waittime + time)
            {
                workingstatus = false;
            }
        }
    }
}