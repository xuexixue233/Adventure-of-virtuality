using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TriggerAnimation : MonoBehaviour
{
    public Image teachImage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player-sb"))
        {
            teachImage.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player-sb"))
        {
            teachImage.gameObject.SetActive(false);
        }
    }
}