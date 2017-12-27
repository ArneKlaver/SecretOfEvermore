using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterPlayerPerson : CharacterPlayer {

    public CharacterPlayerPerson(CharacterManager characterManager, GameObject characterObject, float speed, float maxDistanceBetween) : base(characterManager, characterObject, speed, maxDistanceBetween)
    {
        MaxHealth = 100;
        AttackPower = 30;
        DefendPower = 20;
        MagicDef = 10;
        Evade = 10;
        HitChance = 30;
    }

    public override void Attack()
    {
        Inventory.ActivateSelectedItem();
    }

}
