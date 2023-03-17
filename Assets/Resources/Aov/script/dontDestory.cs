using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestory : MonoBehaviour
{
    public string objectName;
    private void Awake()
    {
        if (GameObject.Find(objectName).gameObject != this.gameObject)
            Destroy(this.gameObject);
        
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
