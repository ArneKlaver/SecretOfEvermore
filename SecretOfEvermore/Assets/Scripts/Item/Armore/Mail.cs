using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mail : Armor {
    public Mail(string name) : base(name)
    {
        UpgradeValues.MaxHealth = 30;
        UpgradeValues.Defend = 15;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
