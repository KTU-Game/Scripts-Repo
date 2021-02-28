using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int selectedItemIndex = 0;
    public InventoryUI inventoryUI;
    public Item[] items = new Item[5];
    private int _maxSize = 5;
    private int _count = 0;

    void Start()
    {
        inventoryUI.UpdateUI(items);
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            EquipItem(0);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            EquipItem(1);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            EquipItem(2);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            EquipItem(3);
        if (Input.GetKeyDown(KeyCode.Alpha5))
            EquipItem(4);

        if (Input.mouseScrollDelta.y < 0)
            EquipItem(++selectedItemIndex);
        else if (Input.mouseScrollDelta.y > 0)
            EquipItem(--selectedItemIndex);
    }

    public void AddItem(Item item)
    {
        if (_count < _maxSize)
        {
            items[_count++] = item;
        }
        inventoryUI.UpdateUI(items);
    }

    public void EquipItem(int index)
    {
        if (index < 0)
            index = _maxSize - 1;
        else if (index > _maxSize - 1)
            index = 0;
        //index = Mathf.Clamp(index, 0, _maxSize-1);
        selectedItemIndex = index;
        inventoryUI.SetSelectedFrame(index);
    }
}
