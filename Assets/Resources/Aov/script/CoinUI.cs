using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CoinUI : MonoBehaviour
{
    public int startCoinQuantity;
    public Text coinQuantity;

    public static int CuttentCoinQuantity;
    // Start is called before the first frame update
    private void Awake()
    {
        if (PlayerPrefs.HasKey("CurrentCoin") && SceneManager.GetActiveScene().buildIndex!=1)
        {
            int PrefsCoin = PlayerPrefs.GetInt("CurrentCoin");
            if (PrefsCoin != 0)
            {
                startCoinQuantity = PrefsCoin;
            }
        }
    }
    void Start()
    {
        CuttentCoinQuantity = startCoinQuantity;
    }

    // Update is called once per frame
    void Update()
    {
        coinQuantity.text=CuttentCoinQuantity.ToString();
    }
}
