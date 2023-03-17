using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwItem : MonoBehaviour
{
    public float speed;
    public int damage;
    public float rotateSpeed;
    public float brokenTime;
    public static bool throwSomething;
    [Header("-- Inventory --")]
    public GameObject OriginalItem;
    public Inventory inventory;

    private float LorR;
    private float playerspeed;
    private Collider2D selfcollider;
    private bool isitemGrounded=false;
    private bool isbroken=false;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        playerspeed = Input.GetAxis("Horizontal");
        throwSomething = true;
        rb2d = GetComponent<Rigidbody2D>();
        if (PlayerController.isLorR)
        {
            LorR = 0.0001f;
        }
        else
        {
            LorR = -0.0001f;
        }
        rb2d.velocity = new Vector2((playerspeed + LorR) / Mathf.Abs(playerspeed + 0.0001f), 1) * speed;
        rb2d.AddForce(new Vector2((playerspeed + LorR) / Mathf.Abs(playerspeed + 0.0001f), 1) * speed, ForceMode2D.Force);
        rb2d.angularVelocity=rotateSpeed;
        rb2d.AddTorque(rotateSpeed* (playerspeed + LorR) / Mathf.Abs(playerspeed + 0.0001f), ForceMode2D.Force);
        selfcollider = this.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((selfcollider.IsTouchingLayers(LayerMask.GetMask("Ground")) ||
            selfcollider.IsTouchingLayers(LayerMask.GetMask("MovingPlatform")) ||
            selfcollider.IsTouchingLayers(LayerMask.GetMask("OneWayPlatform"))))
        {
            if (isbroken == false)
            {
                isitemGrounded = true;
            }
        }
        if (isitemGrounded&&isbroken==false)
        {
            GetComponent<Animator>().SetTrigger("broken");
            SoundManager.playbottleBrokenClip();
            isitemGrounded = false;
            isbroken = true;
            StartCoroutine(itemBroken());
        }
        //transform.Rotate(0, 0, rotateSpeed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            GetComponent<Animator>().SetTrigger("broken");
            other.GetComponent<Enemy>().TakeDamage(damage);
            SoundManager.playbottleBrokenClip();
            StartCoroutine(itemBroken());
        }
        else if (other.gameObject.CompareTag("player"))
        {
            GameObject  newItem=Instantiate(OriginalItem,transform.position, Quaternion.identity)as GameObject;
            newItem.transform.localEulerAngles = transform.localEulerAngles;
            Destroy(gameObject);
        }
    }
    IEnumerator itemBroken()
    {
        yield return new WaitForSeconds(brokenTime);
        Destroy(gameObject);
    }
}