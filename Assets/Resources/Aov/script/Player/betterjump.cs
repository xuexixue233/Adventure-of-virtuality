
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class betterjump : MonoBehaviour
{
    private Rigidbody2D rig;//2D刚体
    public float dropConst;//下坠常数
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();//获取刚体
    }

    // Update is called once per frame
    void Update()
    {
        move();//移动函数
    }
    private void move()
    {    //水平，垂直俩个轴系
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float a = dropConst * 5 - Mathf.Abs(rig.velocity.y);//通过下坠常数，空中速度快为0时，下坠常数a越大，即越快速 度过这个状态
        rig.velocity -= Vector2.up * a * Time.deltaTime;

        //左右移动
        Vector3 vt = new Vector3(h, 0, 0).normalized;//vt为俩个轴系合成的方向向量，normalized单位化
        //空中左右移动，为地面jumpspeedVertiacal倍
        
    }
    //检测否在地面碰撞盒子检测，通过给地面碰撞盒子transform的tag标签为ground
}