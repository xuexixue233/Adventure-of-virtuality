using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBox : MonoBehaviour
{
    public GameObject[] treasure;
    public float delayTime;
    private bool CanOpen;
    private bool isOpened;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isOpened = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Enable"))
        {
            if (CanOpen && !isOpened)
            {
                SoundManager.playTrashbinClip();
                anim.SetTrigger("opening");
                isOpened = true;
                Invoke("GetTreasure", delayTime);
            }
        }
    }
    void GetTreasure()
    {
        Instantiate(treasure[Random.Range(0,treasure.Length)], transform.position, Quaternion.identity);

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            CanOpen= true;

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player") && other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
        {
            CanOpen = false;
        }
    }
}
