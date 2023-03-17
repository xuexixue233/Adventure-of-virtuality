using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canGotoNextScene : MonoBehaviour
{
    public static bool enemyin=false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            enemyin = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            enemyin = false;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            enemyin = true;
        }
    }
}
