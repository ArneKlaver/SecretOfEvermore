using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager  {

    public List<Character> Characters = new List<Character>();
    public List<Character> Enemies = new List<Character>();
    public Character SelectedCharacter = null;

    public CharacterManager()
    {
        // update all characters in the list
        Characters.ForEach(character => character.Start());
        // update all Enemies in the list
        Enemies.ForEach(enemy => enemy.Start());
    }

    public virtual void Start() { }
    public virtual void Update()
    {
        // switch characters at the frame the button is down
        if (Input.GetButtonDown("SwitchCharacter"))
        {
            SwitchCharacters();
        }

        // update all characters in the list
        Characters.ForEach(character => character.Update());
        // update all Enemies in the list
        Enemies.ForEach(enemy => enemy.Update());
    }

    public void SetSelecterCharacter(Character character)
    {
        SelectedCharacter = character;
    }

    // switch to other character ( only works with 2 characters !!! )
    public void SwitchCharacters()
    {
        // look true the list and see if what character is not selected
        foreach (Character character in Characters)
        {
            if (character != SelectedCharacter)
            {
                // set the new selected character
                SelectedCharacter = character;
                // set the camera to this character
                Camera.main.transform.SetParent(SelectedCharacter.CharacterObject.transform);
                Camera.main.transform.position = SelectedCharacter.CharacterObject.transform.Find("CameraSlot").transform.position;
                CameraManager.ChangeCamera(SelectedCharacter);

                return;
            }
        }
    }
}
