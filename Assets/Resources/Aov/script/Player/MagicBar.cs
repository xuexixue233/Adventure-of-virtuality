using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicBar : MonoBehaviour
{
    public int magicBarNum;
    public float coolingTimer;
    public static int MagicCurrent;
    public static int MagicMax;
    public static bool notZero=true;
    public static bool canskill = false;

    private float currentTime = 0.0f;
    private float maxtfill;

    private Image magicbar;
    // Start is called before the first frame update
    void Start()
    {
        maxtfill = (float)MagicMax / (float)magicBarNum;
        currentTime = coolingTimer;
        magicbar = GetComponent<Image>();
        magicbar.fillAmount = maxtfill;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
        {
            canskill = true;
        }
        else
        {
            canskill = false;
        }
        if(SkillAttack.minusMagic == true)
        {
            currentTime -= coolingTimer;
            SkillAttack.minusMagic = false;
        }
        if (currentTime >= coolingTimer)
        {
            notZero = true;
        }
        else
        {
            notZero = false;
        }
        //magicbar.fillAmount = (float)MagicMax / (float)magicBarNum * (float)MagicCurrent / (float)MagicMax;
        if (currentTime < coolingTimer*MagicMax)
        {
            currentTime += Time.deltaTime;
            magicbar.fillAmount = currentTime / (coolingTimer * magicBarNum);
        }

    }
}
