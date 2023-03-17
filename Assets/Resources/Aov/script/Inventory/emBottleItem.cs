using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emBottleItem : MonoBehaviour, IInventoryItem
{
    public string Name
    {
        get
        {
            return "emBottleItem";
        }
    }
    public Sprite _Image;
    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }
    public GameObject throwItemSelf;
    public static int _id = -1;
    public int Id
    {
        get
        {
            return _id;
        }
        set
        {
            _id = value;
        }
    }
    public void OnPickup()
    {
        Destroy(gameObject);
    }
    public void OnUsed()
    {
        GameObject theplayer = GameObject.FindGameObjectWithTag("player");
        Vector2 startTransform= theplayer.transform.position;
        startTransform.y += 50f;
        Debug.Log("bottle");
        Instantiate(throwItemSelf, startTransform, Quaternion.identity);

    }
}
