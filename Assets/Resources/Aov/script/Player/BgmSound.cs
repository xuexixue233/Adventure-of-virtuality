using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmSound : MonoBehaviour
{
    public static AudioClip forestMusic;
    public static AudioSource audioSrc2;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc2 = GetComponent<AudioSource>();
        forestMusic = Resources.Load<AudioClip>("forest-FoolBoyMedia");
    }
    public static void playForestClip()
    {
        audioSrc2.loop = true;
        audioSrc2.volume = 0.4f;
        audioSrc2.clip = forestMusic;
        audioSrc2.Play();
    }
}
