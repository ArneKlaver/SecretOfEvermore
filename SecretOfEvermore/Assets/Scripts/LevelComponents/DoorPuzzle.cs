using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPuzzle : MonoBehaviour {
    public List<TriggerPlate> trigers = new List<TriggerPlate>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    
            bool allPushed = true;
            foreach (TriggerPlate trigger in trigers)
            {
                if (!trigger.IsPushed)
                {
                    allPushed = false;
                }
            }
            if (allPushed)
            {
                Destroy(gameObject);
            }
	}
}
