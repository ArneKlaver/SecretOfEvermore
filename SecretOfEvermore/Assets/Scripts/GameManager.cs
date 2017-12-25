using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    // Public
    public GameObject PlayerStartPosition;
    public GameObject PlayerPrefab;
    public GameObject DogStartPosition;
    public GameObject DogPrefab;
    public GameObject CameraPrefab;
    // Private
    private CharacterManager _charactersManager ;
    private CameraManager _cameraManager ;


    // Use this for initialization
    void Start () {
    _charactersManager = new CharacterManager();
    _cameraManager = new CameraManager(CameraPrefab);



    // instantiate prefab , create Player and add to the character manager
    _charactersManager.Characters.Add(new CharacterPlayer(_charactersManager, Instantiate(PlayerPrefab, PlayerStartPosition.transform.position, PlayerStartPosition.transform.rotation) , 20 , 5));
    //  instantiate prefab , create Dog and add to the character manager
    _charactersManager.Characters.Add(new CharacterDog(_charactersManager, Instantiate(DogPrefab, DogStartPosition.transform.position , DogStartPosition.transform.rotation) , 20 ,5));

    _charactersManager.SetSelecterCharacter(_charactersManager.Characters[0]);
     
    CameraManager.ChangeCamera(_charactersManager.SelectedCharacter);

    }

    // Update is called once per frame
    void Update () {
        _charactersManager.Update();
        _cameraManager.Update();

    }
}
