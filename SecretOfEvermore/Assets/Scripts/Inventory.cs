using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory {
    public static List<Item> Weapon = new List<Item>();
    public static List<Item> Items = new List<Item>();
    public static List<Item> Armor = new List<Item>();

    public static Item SelectedWeapon;
    public static Item SelectedItem;
    public static Item SelectedArmore;

    public static void AddItem(Item item)
    {
        Weapon.Add(item);
    }
    public static void SetSelectdItem(string name)
    {
        SelectedWeapon = Weapon.Find(x => (x.ItemName == name));
    }
    public static void ActivateSelectedItem()
    {
        SelectedWeapon.Activate();
    }

}
