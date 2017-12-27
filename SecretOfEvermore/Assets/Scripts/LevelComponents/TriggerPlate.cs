using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlate : MonoBehaviour {
    public bool IsPushed = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            IsPushed = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            IsPushed = false;
        }
    }
}
