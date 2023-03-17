using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static bool isGameAlive=true;
    public static bool isGameSaying = false;
    public static bool isSkilling = false;
    public static bool isInvincible = false;
    public static CameraShake camShake;
    public static List<IInventoryItem> canUseItems = new List<IInventoryItem>(4) { null,null,null,null};
    public static GameObject CurrentPlayer;
}
