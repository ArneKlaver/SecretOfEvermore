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
            float movementX = Input.GetAxisRaw("Horizontal") * Time.deltaTime * Speed;
            float movementY = Input.GetAxisRaw("Vertical") * Time.deltaTime * Speed;
            // limit the speed
            if (Input.GetButton("Horizontal") && Input.GetButton("Vertical"))
            {
                movementX /= 1.2f;
                movementY /= 1.2f;
            }
            Vector3 movement = new Vector3(movementX, 0, movementY);

            CharacterObject.transform.Translate(movement , Space.World );
            // rotate character to move direction
            if (movement != Vector3.zero)
            {
                CharacterObject.transform.rotation = Quaternion.LookRotation(movement);
            }
        }
        else
        {
            // let the navmesh controll the carachter
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
        UIManager.OpenDeathScreen();
    }

}
