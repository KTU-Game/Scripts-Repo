using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Sprite basicFrameSprite;
    public Sprite selectedFrameSprite;
    public InventorySlot[] slots;

    public void UpdateUI(Item[] items)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (items[i] != null)
            {
                slots[i].itemIcon.enabled = true;
                slots[i].itemIcon.sprite = items[i].icon;
            }
            else
            {
                slots[i].itemIcon.enabled = false;
                slots[i].itemIcon.sprite = null;
            }
        }
    }

    public void SetSelectedFrame(int index)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i == index)
                slots[i].frame.sprite = selectedFrameSprite;
            else
                slots[i].frame.sprite = basicFrameSprite;
        }
    }

}
