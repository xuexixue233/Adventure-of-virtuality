using GameFramework.Procedure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{
    public void startTheGame()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.DeleteAll();
    }
}
