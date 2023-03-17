using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fanvoice : MonoBehaviour
{
    public float fanB;
    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fanbet());
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator fanbet()
    {
        for (i=0;i<25;i++)
        {
            SoundManager.playsbskillClip();
            yield return new WaitForSeconds(fanB);
        }
    }
}
