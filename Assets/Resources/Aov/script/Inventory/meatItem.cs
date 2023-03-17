using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meatItem : MonoBehaviour, IInventoryItem
{
    public string Name
    {
        get
        {
            return "meatItem";
        }
    }
    public Sprite _Image;
    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }
    public int addHp;
    public float pointHigh;
    public GameObject floatPoint;
    private int hpPlus = 0;
    public static int _id = -1;
    public int Id
    {
        get
        {
            return _id;
        }
        set
        {
            _id = value;
        }
    }
    public void OnPickup()
    {
        Destroy(gameObject);
    }
    public void OnUsed()
    {
        Debug.Log("meat");
        PlayerHealth.isUseFood = true;
        SoundManager.playeatMeatClip();
        hpPlus = HealthBar.HealthCurrent + addHp;
        Transform playertrans = GameObject.FindGameObjectWithTag("player").transform;
        GameObject gb = Instantiate(floatPoint, new Vector2(playertrans.position.x, playertrans.position.y + pointHigh), Quaternion.identity) as GameObject;
        gb.transform.GetChild(0).GetComponent<TextMesh>().text = addHp.ToString();
        if (hpPlus > HealthBar.HealthMax)
        {
            HealthBar.HealthCurrent = HealthBar.HealthMax;
        }
        else
        {
            HealthBar.HealthCurrent = hpPlus;
        }
    }
}
