
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class betterjump : MonoBehaviour
{
    private Rigidbody2D rig;//2D����
    public float dropConst;//��׹����
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();//��ȡ����
    }

    // Update is called once per frame
    void Update()
    {
        move();//�ƶ�����
    }
    private void move()
    {    //ˮƽ����ֱ������ϵ
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float a = dropConst * 5 - Mathf.Abs(rig.velocity.y);//ͨ����׹�����������ٶȿ�Ϊ0ʱ����׹����aԽ�󣬼�Խ���� �ȹ����״̬
        rig.velocity -= Vector2.up * a * Time.deltaTime;

        //�����ƶ�
        Vector3 vt = new Vector3(h, 0, 0).normalized;//vtΪ������ϵ�ϳɵķ���������normalized��λ��
        //���������ƶ���Ϊ����jumpspeedVertiacal��
        
    }
    //�����ڵ�����ײ���Ӽ�⣬ͨ����������ײ����transform��tag��ǩΪground
}