using UnityEngine;

public class FuDongEff : MonoBehaviour
{
    Vector3 trans1;//��¼ԭλ��
    Vector2 trans2;//��г�˶��仯��λ�ã�����ó�

    public float zhenFu = 10f;//���
    public float HZ = 1f;//Ƶ��

    private void Awake()
    {
        trans1 = transform.position;
    }

    private void Update()
    {
        trans2 = trans1;
        trans2.y = Mathf.Sin(Time.fixedTime * Mathf.PI * HZ) * zhenFu + trans1.y;

        transform.position = trans2;
    }
}