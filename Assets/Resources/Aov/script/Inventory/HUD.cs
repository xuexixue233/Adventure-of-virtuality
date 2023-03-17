using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    public Inventory Inventory;
    public static Inventory publicinventory;
    public int MaxCount = 10;
    public GameObject[] items;
    public static bool[] emptyBox=new bool[4] {true, true, true, true};
    public static int[] itemCount= new int[4] {0,0,0,0};
    private int canUseItemCount = 0;
    // Use this for initialization
    private void Awake()
    {
        

    }
    void Start()
    {
        Inventory.ItemAdded += InventoryScript_ItemAdded;
        Inventory.ItemMinused += Inventory_ItemMinused;
        publicinventory = Inventory;
    }
    private void Update()
    {
        if (SaveAndLoad.isload)
        {
            if (PlayerPrefs.HasKey("inventoryItem"))
            {
                //List<GameObject> filePrefabs = inventorySave.GetAllPrefabByDirectory("/AOV/Prefab");
                string[] prefsItems = PlayerPrefsX.GetStringArray("inventoryItem");
                for (int i = 0; i < prefsItems.Length; i++)
                {
                    if (itemCount[i] > 0)
                    {
                        for (int k = 0; k <items.Length; k++)
                        {
                            IInventoryItem item = items[k].GetComponent<IInventoryItem>();
                            if (item != null && item.Name == prefsItems[i])
                            {
                                for (int j = 0; j < itemCount[i]; j++)
                                {
                                    GameObject theplayer = GameObject.FindGameObjectWithTag("player");
                                    Vector2 startTransform = theplayer.transform.position;
                                    GameObject itemins = Instantiate(items[k], startTransform, Quaternion.identity) as GameObject;
                                    itemins.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.0001f);

                                }

                            }

                        }
                    }
                }
                SaveAndLoad.isload = false;
            }

        }
        for (int i = 0; i < itemCount.Length; i++)
        {
            if (itemCount[i] <=0)
            {
                itemCount[i] = 0;
            }
        }
    }
    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        bool haspos = false;
        Transform itempanel = transform.Find("itembox");
        for (int j = 0; j < itempanel.childCount; j++)
        {
            Transform slot = itempanel.GetChild(j);
            Transform textTransform = slot.GetChild(0).GetChild(1);
            Text txtCount = textTransform.GetComponent<Text>();
            if (itemCount[j] != 0)
            {
                if(e.Item.Id == j)
                {
                    if (itemCount[j] < MaxCount)
                    {
                        itemCount[j]++;
                        txtCount.text = "<color=white>" + itemCount[j] + "</color>";
                        haspos = true;
                        break;
                    }

                }
            }
        }
        if (haspos == false)
        {
            for (int i = 0; i < itempanel.childCount; i++)
            {
                // Border... Image
                Transform slot = itempanel.GetChild(i);
                Transform imageTransform = slot.GetChild(0).GetChild(0);
                Transform textTransform = slot.GetChild(0).GetChild(1);
                Image image = imageTransform.GetComponent<Image>();
                Text txtCount = textTransform.GetComponent<Text>();
                if (e.Item.Id != i)
                {
                    if (!image.enabled)
                    {
                        image.enabled = true;
                        image.sprite = e.Item.Image;
                        e.Item.Id = i;
                        itemCount[i] = 1;
                        emptyBox[i] = false;
                        GameController.canUseItems[i] = e.Item;
                        canUseItemCount++;
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

        }
    }

    private void Inventory_ItemMinused(object sender, InventoryEventArgs e)
    {
        Transform itempanel = transform.Find("itembox");
        for (int i = 0; i < itempanel.childCount; i++)
        {
            // Border... Image
            Transform slot = itempanel.GetChild(i);
            Transform imageTransform = slot.GetChild(0).GetChild(0);
            Transform textTransform = slot.GetChild(0).GetChild(1);
            Image image = imageTransform.GetComponent<Image>();
            Text txtCount = textTransform.GetComponent<Text>();
            if (e.Item.Id != i)
            {
            }
            else if (itemCount[i] >1)
            {
                itemCount[i]--;
                if (itemCount[i] == 1)
                {

                    txtCount.text = "<color=white></color>";
                }
                else
                {
                    txtCount.text = "<color=white>" + itemCount[i] + "</color>";
                }
                break;
            }
            else if (itemCount[i] == 1)
            {
                itemCount[i]=0;
                image.sprite = null;
                image.enabled = false;
                txtCount.text = "<color=white></color>";
                GameController.canUseItems[i]=null;
                e.Item.Id = -1;
                break;
            }
            else
            {
                break;
            }
        }
    }
}
