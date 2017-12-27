using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager {
    private static GameObject _hud;
    private static GameObject _DogStats;
    private static GameObject _PlayerStats;
    private static GameObject _EndGame;
    private static GameObject _Death;
    private static GameObject _Inventory;
    public static bool IsInStats = true;
    public static bool IsInInventory = false;

    public UIManager()
    {
        _hud = GameObject.Find("HUD");
        _DogStats = GameObject.Find("DogStats");
        _PlayerStats = GameObject.Find("PlayerStats");
        _EndGame = GameObject.Find("EndGame");
        _Death = GameObject.Find("Death");
        _Inventory = GameObject.Find("Inventory");
    }


    public void Update()
    {
        // stat menu
        if (Input.GetButtonDown("StatsMenu"))
        {
            if (!IsInStats)
            {
                OpenPanelPlayerStat();
                IsInStats = true;
            }
            else
            {
                CloseAllPanels();
                IsInStats = false;
            }
        }
        //switch character
        if (IsInStats && Input.GetButtonDown("Horizontal"))
        {
            if (_DogStats.activeSelf)
            {
                OpenPanelPlayerStat();
            }
            else if (_PlayerStats.activeSelf)
            {
                OpenPanelDogStat();
            }
        }
        // Inventory
        if (Input.GetButtonDown("Inventory"))
        {
            if (!IsInInventory)
            {
                OpenInventory();
                IsInInventory = true;
            }
            else
            {
                CloseAllPanels();
                IsInInventory = false;
            }
        }
    }
    public static void CloseAllPanels()
    {
        Time.timeScale = 1;
        _DogStats.SetActive(false);
        _PlayerStats.SetActive(false);
        _EndGame.SetActive(false);
        _Death.SetActive(false);
        _Inventory.SetActive(false);
    }
    public static void OpenPanelDogStat()
    {
        CloseAllPanels();
        Time.timeScale = 0;
        _DogStats.SetActive(true);
    }
    public static void OpenPanelPlayerStat()
    {
        CloseAllPanels();
        Time.timeScale = 0;
        _PlayerStats.SetActive(true);
    }
    public static void OpenEndGameScreen()
    {
        CloseAllPanels();
        Time.timeScale = 0;
        _EndGame.SetActive(true);
    }
    public static void OpenDeathScreen()
    {
        CloseAllPanels();
        Time.timeScale = 0;
        _Death.SetActive(true);
    }
    public static void OpenInventory()
    {
        _Inventory.GetComponent<InventoryPanel>().UpdateItemText();
        CloseAllPanels();
        Time.timeScale = 0;
        _Inventory.SetActive(true);
    }
}
