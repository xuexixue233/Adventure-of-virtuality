using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAttack : MonoBehaviour
{
    public GameObject SkillObject;
    public float StopAttackTime;
    public float OnceAttackTime;
    public static bool skilling=false;
    public static bool minusMagic = false;
    private bool onceSkill=false;
    private PlayerInputActions controls;

    //void Awake()
    //{
    //    controls = new PlayerInputActions();
    //    controls.GamePlay.Skill.started += ctx => Skill();

    //}
    //void OnEnable()
    //{
    //    controls.GamePlay.Enable();
    //}
    //void OnDisable()
    //{
    //    controls.GamePlay.Disable();
    //}
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        Skill();
    }
    void Skill()
    {
        if ((Input.GetButtonDown("Skill") || Input.GetMouseButtonDown(1)))
        {
            if (GameController.isGameAlive == true && onceSkill == false && MagicBar.notZero == true && GameController.isGameSaying == false)
            {
                onceSkill = true;
                minusMagic = true;
                Instantiate(SkillObject, transform.position, transform.rotation);
                skilling = true;
                GameController.isSkilling = true;
                Invoke("stopSkill", StopAttackTime);
            }
        }
       
    }
    void stopSkill()
    {
        GameController.isSkilling = false;
        Invoke("onceSkillAttack", OnceAttackTime);
    }
    void onceSkillAttack()
    {
        onceSkill = false;
    }
}
