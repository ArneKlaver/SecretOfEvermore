using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterDog : Character {

    public float MaxDistanceBetween = 0;

    public CharacterDog(CharacterManager characterManager, GameObject characterObject, float speed , float maxDistanceBetween) : base(characterManager, characterObject, speed)
    {
        MaxDistanceBetween = maxDistanceBetween;

        // NavMeshAgent creation
        NavMeshAgent navMeshAgent = CharacterObject.AddComponent<NavMeshAgent>();
        navMeshAgent.stoppingDistance = 5;
        navMeshAgent.speed = Speed;
        navMeshAgent.acceleration = 2000;
        navMeshAgent.angularSpeed = 360;
        navMeshAgent.autoBraking = true;

    }
    // Use this for initialization
    public override void Start() {
       

    }

    // Update is called once per frame
    public override void Update () {

        if (_characterManager.SelectedCharacter == this)
        {
            CharacterObject.GetComponent<NavMeshAgent>().enabled = false;
            // controll this character
            float movementX = Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
            float movementY = Input.GetAxis("Vertical") * Time.deltaTime * Speed;
            CharacterObject.transform.Translate(movementX, 0, movementY , Space.World);
        }
        else
        {
            CharacterObject.GetComponent<NavMeshAgent>().enabled = true;
            CharacterObject.GetComponent<NavMeshAgent>().SetDestination(_characterManager.SelectedCharacter.CharacterObject.transform.position);

        }
    }
}
