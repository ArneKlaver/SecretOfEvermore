using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : EverMorePanel {
    public GameObject RootObject;

    List<Text> _items = new List<Text>();
    public void Start()
    {
        //_panelRoot = GameObject.Find("ItemsText");
        foreach (Transform child in RootObject.transform)
        {
            _items.Add(child.GetComponent<Text>());
        }
    }

    public void UpdateItemText()
    {
        if (_items.Count == 0 )
        {
            Start();
        }
        int index = 0;
    
        foreach (Weapon weapon in Inventory.Weapon)
        {
            if (index > _items.Count)
                return;
            _items[index].text = weapon.ItemName;
            index++;
        }
        foreach (Armor armor in Inventory.Armor)
        {
            if (index > _items.Count)
                return;
            _items[index].text = armor.ItemName;
            index++;
        }
        foreach (Item item in Inventory.Items)
        {
            if (index > _items.Count)
                return;
            _items[index].text = item.ItemName;
            index++;
        }
    }
}
