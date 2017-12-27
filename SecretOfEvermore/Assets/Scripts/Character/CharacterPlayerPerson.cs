using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterPlayerPerson : CharacterPlayer {

    public CharacterPlayerPerson(CharacterManager characterManager, GameObject characterObject, float speed, float maxDistanceBetween) : base(characterManager, characterObject, speed, maxDistanceBetween)
    {

    }

    public override void Attack()
    {
        Inventory.ActivateSelectedItem();
    }

}
