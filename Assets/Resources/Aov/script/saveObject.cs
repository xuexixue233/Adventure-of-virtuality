using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class saveObject : MonoBehaviour
{
    [Header("-- Player Data --")]
    [SerializeField] int Level;
    [SerializeField] int Coin = 0;
    public static bool isSaving = false;
    #region Save and Load
    public void Save()
    {
        SaveByPlayerPrefs();
        isSaving = true;
    }
    //public void Load()
    //{
    //    LoadFromPlayerPrefs();
    //}
    #endregion    
    #region PlayerPrefs
    public void SaveByPlayerPrefs()
    {
        PlayerPrefs.SetInt("Level", Level);
        PlayerPrefs.SetInt("Coin", Coin);
        inventorySave.saveInventory();
        PlayerPrefs.Save();
    }

    //public void LoadFromPlayerPrefs()
    //{
    //    Level=PlayerPrefs.GetInt("Level");
    //    Coin=PlayerPrefs.GetInt("Coin");
    //}
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        Level = SceneManager.GetActiveScene().buildIndex;
        Coin = CoinUI.CuttentCoinQuantity;
        if (!SaveAndLoad.isload)
        {
            Save();
        }

    }

    // Update is called once per frame
    void Update()
    {

        Coin = CoinUI.CuttentCoinQuantity;
    }
}
