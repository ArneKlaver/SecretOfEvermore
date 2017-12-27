using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robe : Armor {
    public Robe(string name) : base(name)
    {
        UpgradeValues.MaxHealth = 10;
        UpgradeValues.MagicDef = 20;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
