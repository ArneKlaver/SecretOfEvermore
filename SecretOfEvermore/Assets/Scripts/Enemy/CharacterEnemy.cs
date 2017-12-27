using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEnemy : Character {
    public float Damage = 10;
    public float AttackRange = 100;
    public bool CanAttack = false;
    public float AttackCooldown = 0;
    private float _attackCounter = 0;

    public CharacterEnemy(CharacterManager characterManager, GameObject characterObject, float speed) : base(characterManager, characterObject, speed)
    {
    }

    // Use this for initialization
    public override void Start() {
        // set a Enemy tag on the enemy object
        CharacterObject.tag = "Enemy";

	}

    // Update is called once per frame
    public override void Update() {

        // Attack Counter
        if (!CanAttack)
        {
            _attackCounter += Time.deltaTime;
            if (_attackCounter > AttackCooldown)
            {
                CanAttack = true;
                _attackCounter = 0;
            }
        }
	}

    public override void Death()
    {
        _characterManager.Enemies.Remove(this);

        GameObject.Destroy(CharacterObject);
    }

}
