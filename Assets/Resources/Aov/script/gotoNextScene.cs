using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gotoNextScene : MonoBehaviour
{
    public int SceneCount;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            if (SceneManager.GetActiveScene().buildIndex<SceneCount-1)
            {
                saveCurrentData();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }
        }
    }
    public void saveCurrentData()
    {
        
        PlayerPrefs.SetInt("CurrentCoin", CoinUI.CuttentCoinQuantity);
        inventorySave.saveInventory();
        PlayerPrefs.Save();
    }
}
