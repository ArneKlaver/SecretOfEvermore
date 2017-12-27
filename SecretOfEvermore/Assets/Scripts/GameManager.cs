using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    // Public
    public GameObject PlayerStartPosition;
    public GameObject PlayerPrefab;
    public GameObject DogStartPosition;
    public GameObject DogPrefab;
    public GameObject CameraPrefab;
    public GameObject EnemyFlowerPrefab;
    public GameObject EnemyFlowerRoot;
    public GameObject Canvas;
    // Private
    private static CharacterManager CharactersManager ;
    private CameraManager _cameraManager ;
    private CharacterPanel _characterPanel;
    private Inventory _inventory;
    private UIManager _uiManager;

    public static CharacterManager GetCharacterManager() { return CharactersManager; }
  
    // Use this for initialization
    void Start () {
    Canvas.SetActive(true);
    // isntantiate managers
    CharactersManager = new CharacterManager();
    _cameraManager = new CameraManager(CameraPrefab);
    _uiManager = new UIManager();
    UIManager.CloseAllPanels();
        
     // instantiate prefab , create Player and add to the character manager
     CharactersManager.Characters.Add(new CharacterPlayerPerson(CharactersManager, Instantiate(PlayerPrefab, PlayerStartPosition.transform.position, PlayerStartPosition.transform.rotation) , 20 , 5));
    
    //  instantiate prefab , create Dog and add to the character manager
    CharactersManager.Characters.Add(new CharacterPlayerDog(CharactersManager, Instantiate(DogPrefab, DogStartPosition.transform.position , DogStartPosition.transform.rotation) , 20 ,5));
    // set default character
    CharactersManager.SetSelecterCharacter(CharactersManager.Characters[0]);
    CameraManager.ChangeCamera(CharactersManager.SelectedCharacter);

        // isntantiate Enemy flowers
        foreach (Transform child in EnemyFlowerRoot.transform)
        {
            CharactersManager.Enemies.Add(new CharacterEnemyFlower(CharactersManager, Instantiate(EnemyFlowerPrefab, child.transform.position, child.transform.rotation), 20));
        }

    // Fill the Inventory with availible weapons
    Inventory.Weapon.Add(new Sword("Sword"));
    Inventory.Weapon.Add(new Axe("Axe"));
    Inventory.Weapon.Add(new Spear("Spear"));
    // set default item
    Inventory.SetSelectdWeapon("Sword");

        Inventory.Armor.Add(new Leather("Leather"));
        Inventory.Armor.Add(new Mail("Mail"));
        Inventory.Armor.Add(new Robe("Robe"));
        Inventory.SetSelectdArmore("Leather"); 

        // calls tart functions
        CharactersManager.Start();

    }
    
    // Update is called once per frame
    void Update () {
        CharactersManager.Update();
        _cameraManager.Update();
        _uiManager.Update();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
