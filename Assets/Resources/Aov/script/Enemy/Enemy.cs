using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int damage;
    public float flashTime;
    public GameObject bloodEffect;
    public GameObject dropCoin;
    public GameObject floatPoint;
    private bool isFlash=false;
    private SpriteRenderer sr;
    private Color originalColor;
    private PlayerHealth playerHealth;
    // Start is called before the first frame update
    public void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerHealth>();
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    // Update is called once per frame
    public void Update()
    {
        if (health <= 0)
        {
            Instantiate(dropCoin, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int getdamage)
    {
        if (isFlash == false)
        {
            GameObject gb= Instantiate(floatPoint, transform.position, Quaternion.identity)as GameObject; 
            gb.transform.GetChild(0).GetComponent<TextMesh>().text = getdamage.ToString(); 
            health -= getdamage; 
            FlashColor(flashTime); 
            Instantiate(bloodEffect, transform.position, Quaternion.identity); 
            GameController.camShake.Shake();
        }
    }

    void FlashColor(float time)
    {
        sr.color = Color.red;
        isFlash = true;
        Invoke("ResetColor", time);
    }
    void ResetColor()
    {
        sr.color = originalColor;
        isFlash = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player")&&other.GetType().ToString()=="UnityEngine.CapsuleCollider2D")
        {
            if (playerHealth != null&& GameController.isGameSaying == false&&PlayerHealth.isDie==false)
            {
                playerHealth.DamagePlayer(damage);
            }
            else
            {
            transform.position = Vector2.MoveTowards(transform.position,
                                                     GameObject.FindGameObjectWithTag("player").GetComponent<Transform>().position,
                                                     -2000 * Time.deltaTime);
            }
        }
    }
}
