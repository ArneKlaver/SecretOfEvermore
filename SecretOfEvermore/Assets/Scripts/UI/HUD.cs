using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
    // DOG HUD variables
    private Text _dogHealthText;
    private Text _dogMaxHealthText;
    private Text _dogStaminaText;
    // PLAYER HUD variables
    private Text _playerHealthText;
    private Text _playerMaxHealthText;
    private Text _playerStaminaText;

    private Character _player;
    private Character _dog;


    // Use this for initialization
    void Start () {
        _player = GameManager.GetCharacterManager().GetPlayer();
        _dog = GameManager.GetCharacterManager().GetDog();

        // get all of the text components that need to change from the dog
        Transform dogHud = GameObject.FindGameObjectWithTag("HUD").transform.Find("DogHUD");
        _dogHealthText = dogHud.Find("CurrentHealth").GetComponent<Text>();
        _dogMaxHealthText = dogHud.Find("MaxHealth").GetComponent<Text>();
        _dogStaminaText = dogHud.Find("StaminaNumber").GetComponent<Text>();
        // get all of the text components that need to change from the player
        Transform playerHud = GameObject.FindGameObjectWithTag("HUD").transform.Find("PlayerHUD");
        _playerHealthText = playerHud.Find("CurrentHealth").GetComponent<Text>();
        _playerMaxHealthText = playerHud.Find("MaxHealth").GetComponent<Text>();
        _playerStaminaText = playerHud.Find("StaminaNumber").GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update () {
        UpdateDogHud();
        UpdatePlayerHud();
    }

    private void UpdateDogHud()
    {
       // set the hud of the dog
       _dogHealthText.GetComponent<Text>().text = _dog.Health.ToString();
       _dogMaxHealthText.text = _dog.MaxHealth.ToString();
  
       if (_dog.Stamina < 100)
       {
           _dogStaminaText.enabled = true;
           _dogStaminaText.text = _dog.Stamina.ToString();
  
           if (_dog.Stamina == 100)
           {
               _dogStaminaText.enabled = false;
           }
       }
    }
    private void UpdatePlayerHud()
    {
        // set the hud of the player
       _playerHealthText.text = _player.Health.ToString();
       _playerMaxHealthText.text = _player.MaxHealth.ToString();
   
       if (_player.Stamina < 100)
       {
           _playerStaminaText.enabled = true;
           _playerStaminaText.text = _dog.Stamina.ToString();
   
           if (_player.Stamina == 100)
           {
               _playerStaminaText.enabled = false;
           }
       }
    }
}
