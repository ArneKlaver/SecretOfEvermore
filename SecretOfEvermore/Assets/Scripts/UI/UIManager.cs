using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager {
    private static GameObject _hud;
    private static GameObject _DogStats;
    private static GameObject _PlayerStats;
    public static bool IsInStats = true;
    public UIManager()
    {
        _hud = GameObject.Find("HUD");
        _DogStats = GameObject.Find("DogStats");
        _DogStats.SetActive(false);
        _PlayerStats = GameObject.Find("PlayerStats");
        _PlayerStats.SetActive(false);

    }

    public void Update()
    {
        if (Input.GetButtonDown("StatsMenu"))
        {
            if (!IsInStats)
            {
                Time.timeScale = 0;
                OpenPanelPlayerStat();
                IsInStats = true;
            }
            else
            {
                Time.timeScale = 1;
                CloseAllPanels();
                IsInStats = false;
            }
        }
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
    }
    public static void CloseAllPanels()
    {
        _DogStats.SetActive(false);
        _PlayerStats.SetActive(false);
    }
    public static void OpenPanelDogStat()
    {
         CloseAllPanels();
        _DogStats.SetActive(true);
    }
    public static void OpenPanelPlayerStat()
    {
         CloseAllPanels();
        _PlayerStats.SetActive(true);
    }
}
