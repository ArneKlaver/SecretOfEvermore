using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct Upgrades
{
    public int MaxHealth;
    public int Attack;
    public int Defend;
    public int MagicDef;
    public int Evade;
    public int Hit;
}
public enum ItemType
{
    NONE,
    WEAPON,
    ARMOR,
    ITEM
}
public class Item {
    public string ItemName = "";
    public Upgrades UpgradeValues;
    public ItemType Type = ItemType.NONE;

    public Item(string name) { ItemName = name; }
    public virtual void Activate()
    {
        Inventory.ActivateSelectedItem();
    }


}
