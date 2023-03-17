using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showimage : MonoBehaviour
{
    public float waittime = 0;
    public float time = 1.0f;
    public float timer = 0;
    public float finfill = 1;
    private float incFill = 0.0f;
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
            if (timer > waittime && incFill <= finfill)
            {
                incFill = (timer - waittime) / time;

                gameObject.GetComponent<Image>().fillAmount= incFill;
            }
            if (timer > waittime + time)
            {
                workingstatus = false;
            }
        }
    }
}