using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boskShake : MonoBehaviour
{
    private Animator boskAni;
    // Start is called before the first frame update
    void Start()
    {
        boskAni = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D" && Mathf.Abs(other.gameObject.GetComponent<Rigidbody2D>().velocity.x)>0.1)
        {
            boskAni.SetTrigger("playerIn");

        }
        if (other.gameObject.CompareTag("Enemy") )
        {
            boskAni.SetTrigger("playerIn");

        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D" && Mathf.Abs(other.gameObject.GetComponent<Rigidbody2D>().velocity.x) > 0.1)
        {
            boskAni.SetTrigger("playerIn");

        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            boskAni.SetTrigger("playerIn");

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D" && Mathf.Abs(other.gameObject.GetComponent<Rigidbody2D>().velocity.x) > 0.1)
        {
            boskAni.SetTrigger("playerIn");
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            boskAni.SetTrigger("playerIn");

        }
    }
}
