using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leather : Armor {
    public Leather(string name) : base(name)
    {
        UpgradeValues.MaxHealth = 30;
        UpgradeValues.Evade = 10;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
