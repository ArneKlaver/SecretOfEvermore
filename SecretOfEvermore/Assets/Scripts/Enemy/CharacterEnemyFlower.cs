using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEnemyFlower : CharacterEnemy {
    public bool AttackAnimation = false;

    public CharacterEnemyFlower(CharacterManager characterManager, GameObject characterObject, float speed) : base(characterManager, characterObject, speed)
    {
        Damage = 10;
        AttackCooldown = 3;
    }

    public override void Update()
    {
        base.Update();
        if (CanAttack)
        {
            CanAttack = false;
            Attack();
        }
    }
    public override void Attack()
    {
        // see if the player is in atack field AND atack if there is a hit
        if (CheckForPlayer(Vector3.forward))
            return;
        if(CheckForPlayer(Vector3.back))
            return;
        if(CheckForPlayer(Vector3.right))
            return;
        if(CheckForPlayer(Vector3.left))
            return;
        
    }
    private bool CheckForPlayer(Vector3 direction)
    {
        RaycastHit hit;
        if (Physics.Raycast(CharacterObject.transform.position, direction, out hit , AttackRange))
        {
            if (hit.transform.gameObject.tag == "Player")
            {
                DoAttack(direction, hit.transform.gameObject);
                return true;
            }
        }
        return false;
    }
    private void DoAttack(Vector3 direction , GameObject targetHit)
    {
        targetHit.GetComponent<VisualCharacter>().Character.TakeDamage(Damage);
        // Activate attack "animation"
        AttackAnimation = true;
    }
}
