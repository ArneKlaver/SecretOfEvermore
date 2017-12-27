using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory {
    public static List<Item> Weapon = new List<Item>();
    public static List<Item> Items = new List<Item>();
    public static List<Item> Armor = new List<Item>();

    public static Item SelectedWeapon;
    public static Item SelectedItem;
    public static Item SelectedArmor;

    public static void SetSelectdItem(string name)
    {
        SelectedItem = Items.Find(x => (x.ItemName == name));
    }
    public static void SetSelectdWeapon(string name)
    {
        SelectedWeapon = Weapon.Find(x => (x.ItemName == name));
    }
    public static void SetSelectdArmore(string name)
    {
        SelectedArmor = Armor.Find(x => (x.ItemName == name));
    }
    public static void ActivateSelectedItem()
    {
        SelectedWeapon.Activate();
    }

}
