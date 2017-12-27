using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class EverMorePanel : MonoBehaviour {
    GameObject _panelRoot;

    public void ActivatePanel()
    { _panelRoot.SetActive(true); }
    public void DeActivatePanel()
    { _panelRoot.SetActive(false); }
}
