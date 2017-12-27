using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterPlayer : Character {

    public float MaxDistanceBetween = 0;
    public bool IsDeath = false;

    public int Exp = 0;
    public int ExpNeeded = 0;

    public CharacterPlayer(CharacterManager characterManager, GameObject characterObject, float speed, float maxDistanceBetween) : base(characterManager, characterObject, speed)
    {
        MaxDistanceBetween = maxDistanceBetween;

        // NavMeshAgent creation
        NavMeshAgent navMeshAgent = CharacterObject.AddComponent<NavMeshAgent>();
        navMeshAgent.stoppingDistance = 5;
        navMeshAgent.speed = Speed;
        navMeshAgent.acceleration = 2000;
        navMeshAgent.angularSpeed = 360;
        navMeshAgent.autoBraking = true;
        CharacterObject.tag = "Player";

    }

    // Update is called once per frame
    public override void Update() {
        // movement
        if (_characterManager.SelectedCharacter == this)
        {
            CharacterObject.GetComponent<NavMeshAgent>().enabled = false;
            // controll this character
            float movementX = Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
            float movementY = Input.GetAxis("Vertical") * Time.deltaTime * Speed;
            CharacterObject.transform.Translate(movementX, 0, movementY, Space.World);
        }
        else
        {
            CharacterObject.GetComponent<NavMeshAgent>().enabled = true;
            CharacterObject.GetComponent<NavMeshAgent>().SetDestination(_characterManager.SelectedCharacter.CharacterObject.transform.position);
        }

        if (Input.GetButtonDown("Attack"))
        {
            Attack();
        }
    }
    public override void Death()
    {
        IsDeath = true;
        _characterManager.CheckArePlayersDeath();
    }

}
