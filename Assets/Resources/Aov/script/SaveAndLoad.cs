using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveAndLoad : MonoBehaviour
{
    public int Level;
    public int Coin;
    public static bool isload=false;
    void LoadFromPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            Level = PlayerPrefs.GetInt("Level");
        }
        else
        {
            Level = 1;
        }
        if (PlayerPrefs.HasKey("Coin"))
        {
            Coin = PlayerPrefs.GetInt("Coin");
        }
        else
        {
            Coin = 0;
        }
        if (PlayerPrefs.HasKey("ItemCount"))
        {
            HUD.itemCount = PlayerPrefsX.GetIntArray("ItemCount");
        }
    }
    public void Load()
    {
        if (Level == 1)
        {
            PlayerPrefs.DeleteAll();
        }
        LoadFromPlayerPrefs();
        isload = true;
        SceneManager.LoadScene(Level);
    }
}
