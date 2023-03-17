using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgm : MonoBehaviour
{
    public static bool playbgm=false;
    public bool firstPlay=true;
    // Update is called once per frame
    void Update()
    {
        if (playbgm && firstPlay)
        {
            BgmSound.playForestClip();
            playbgm = false;
            firstPlay = false;
        }
    }
}
