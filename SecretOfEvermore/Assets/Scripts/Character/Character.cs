using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character {
    protected CharacterManager _characterManager;
    public GameObject CharacterObject;

    public float speed = 0;

    public string Name = "";
    public int Health = 100;
    public int Level = 0;
    public int attack = 0;
    public int def = 0;

    public Character(CharacterManager characterManager, GameObject characterObject, float speed)
    {
        _characterManager = characterManager;
        CharacterObject = characterObject;
    }

    public virtual void Start() { }

   public virtual void Update() { }
}
