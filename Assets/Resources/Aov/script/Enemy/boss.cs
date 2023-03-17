using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boss : Enemy
{
    public GameObject bossBar;
    public GameObject inhealthBar;
    private int HealthMax;
    private Image healthbar;
    private new void Start()
    {
        base.Start();
        healthbar = inhealthBar.GetComponent<Image>();
        HealthMax = health;
        Debug.Log(health);
    }
    private new void Update()
    {
        base.Update();
        if (gameObject&&gameObject.activeInHierarchy)
        {
            bossBar.SetActive(true);
        }

        healthbar.fillAmount = (float)health / (float)HealthMax;
    }
}
