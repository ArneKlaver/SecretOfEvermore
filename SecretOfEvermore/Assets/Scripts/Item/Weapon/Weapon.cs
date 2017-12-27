using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item {
    public Weapon(string name) : base(name) { Type = ItemType.WEAPON; }
    public float Range;
    


    public override void Activate()
    {

    }


}
