using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character {
    protected CharacterManager _characterManager;
    public GameObject CharacterObject;

    public float Speed = 0;

    public string Name = "";
    public int Health = 100;
    public int MaxHealth = 100;

    public int Stamina = 100;
    public int Level = 0;
    public int AttackPower = 0;
    public int DefendPower = 0;
    public int MagicDef = 0;
    public int Evade = 0;
    public int HitChance = 0; 

    
    public Character(CharacterManager characterManager, GameObject characterObject, float speed)
    {
        // set variables
        _characterManager = characterManager;
        CharacterObject = characterObject;
        Speed = speed;
        CharacterObject.GetComponent<VisualCharacter>().Character = this;
    }

    public virtual void Start() { }

    public virtual void Update() { }
    //Character take damage dunction
    public virtual void TakeDamage(float damage)
    {
        // take damage ( takes defence into acount )
        Health -= (int)(damage/100.0f*(100- DefendPower));
        
        if (Health <= 0)
        {
            Death();
        }
    }
    //Character death function
    public virtual void Death()
    {
        _characterManager.Characters.Remove(this);
        _characterManager.Enemies.Remove(this);

        GameObject.Destroy(CharacterObject);
    }
    public virtual void Attack()
    { }
}
