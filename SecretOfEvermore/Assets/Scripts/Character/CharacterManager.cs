using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager  {

    public List<Character> Characters = new List<Character>();
    public List<Character> Enemies = new List<Character>();
    public Character SelectedCharacter = null;

    public virtual void Start() { }
    public virtual void Update()
    {
        // update all characters in the list
        Characters.ForEach(character => character.Update());
        // update all Enemies in the list
        Enemies.ForEach(enemy => enemy.Update());
    }

    public void SetSelecterCharacter(Character character)
    {

    }
}
