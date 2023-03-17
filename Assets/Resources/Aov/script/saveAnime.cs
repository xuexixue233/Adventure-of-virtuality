using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveAnime : MonoBehaviour
{
    public GameObject SaveUi;
    public float savetime;

    // Update is called once per frame
    void Update()
    {
        if (saveObject.isSaving)
        {
            SaveUi.SetActive(true);
            StartCoroutine(saveFalse());
        }   
    }


    IEnumerator saveFalse()
    {
        yield return new WaitForSeconds(savetime);
        SaveUi.SetActive(false);
        saveObject.isSaving = false;
    }
}
