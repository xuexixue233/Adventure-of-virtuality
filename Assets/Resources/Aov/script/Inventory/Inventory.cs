using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private const int SLOTS = 10;

    private IList<IInventoryItem> mItems = new List<IInventoryItem>();

    public event EventHandler<InventoryEventArgs> ItemAdded;

    public event EventHandler<InventoryEventArgs> ItemMinused;

    public void AddItem(IInventoryItem item)
    {
        bool isRepeated = false;
        if (mItems.Count < SLOTS)
        {
            Collider2D collider = (item as MonoBehaviour).GetComponent<BoxCollider2D>();
            if (collider.enabled)
            {
                //collider.enabled = false;
                for (int i = 0; i < mItems.Count; i++)
                {
                    if (item.Id == mItems[i].Id)
                    {
                        isRepeated = true;
                    }
                }
                if (isRepeated == false)
                {
                    mItems.Add(item);
                }
                item.OnPickup();

                ItemAdded?.Invoke(this, new InventoryEventArgs(item));
            }
        }
    }
    public void UseItem(IInventoryItem item)
    {
        ItemMinused?.Invoke(this, new InventoryEventArgs(item));

        item.OnUsed();
    }
}
