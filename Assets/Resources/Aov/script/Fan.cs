using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public float speed;
    public int damage;
    public float rotateSpeed;
    public float tuning;
    private Rigidbody2D rb2d;
    private Transform playerTransform;
    private Transform fanTransform;
    private Vector2 startSpeed;
    private CameraShake camShake;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.right * speed;
        startSpeed = rb2d.velocity;
        playerTransform = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();
        fanTransform= GetComponent<Transform>(); 
        camShake = GameObject.FindGameObjectWithTag("CameraShake").GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed);
        float y = Mathf.Lerp(transform.position.y, playerTransform.position.y, tuning);
        transform.position = new Vector3(transform.position.x, y, 0.0f);
        rb2d.velocity = rb2d.velocity - startSpeed/2 * Time.deltaTime;
        if (Mathf.Abs(transform.position.x - playerTransform.position.x) < 10.0f)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") && other.GetType().ToString() == "UnityEngine.BoxCollider2D")
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
