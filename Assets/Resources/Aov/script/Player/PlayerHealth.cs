using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int magic;
    public float dieTime;
    public float hittime;
    public float invincibilityTime;
    public Color flashColor;
    public GameObject DieAnime;
    private Color defaultColor;
    public static bool isDie = false;
    public static bool isUseFood = false;
    private Animator anim;
    private ScreenFlash sf;
    private Rigidbody2D rb2d;
    private PolygonCollider2D polygonCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        isDie = false;
        HealthBar.HealthMax = maxHealth;
        HealthBar.HealthCurrent = health;
        MagicBar.MagicMax = magic;
        MagicBar.MagicCurrent = magic;
        anim = GetComponent<Animator>();
        sf = GetComponent<ScreenFlash>();
        rb2d = GetComponent<Rigidbody2D>();
        defaultColor = GetComponent<Renderer>().material.color;
        polygonCollider2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.isInvincible)
        {

            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"));
        }
        else
        {

            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"),false);
        }
        //if (isDie)
        //{
        //    rb2d.velocity = new Vector2(0, 0);
        //}
        if (isUseFood)
        {
            health = HealthBar.HealthCurrent;
            isUseFood=!isUseFood;
        }
    }
    public void DamagePlayer(int damage)
    {
        sf.FlashScreen();
        GameController.isGameAlive = false;
        health -= damage;
        if (health <= 0)
        {
            health = 0;
        }
        HealthBar.HealthCurrent = health;
        if (health > 0)
        {

            SoundManager.playHitClip();
            anim.SetTrigger("hit");
            GameController.isInvincible = true;
            //GameController.isGameAlive = false;
            StartCoroutine(StartHit());
        }
        else
        {
            //GameController.isGameAlive = false;
            isDie = true;
            rb2d.velocity = new Vector2(0, 0);
            GameController.isInvincible = true;
            anim.SetTrigger("die");
            DieAnime.SetActive(true);
            StartCoroutine(PlayerDieAnime());
            SoundManager.playSadClip();
        }
    }
    IEnumerator PlayerDieAnime()
    {
        yield return new WaitForSeconds(dieTime);
        Destroy(gameObject);
    }
    IEnumerator StartHit()
    {
        yield return new WaitForSeconds(hittime);
        GameController.isGameAlive = true;
        GetComponent<Renderer>().material.color = flashColor;
        StartCoroutine(Hitinvincibility());
    }
    IEnumerator Hitinvincibility()
    {
        yield return new WaitForSeconds(invincibilityTime);
        GetComponent<Renderer>().material.color = defaultColor;
        GameController.isInvincible = false;
    }
}
