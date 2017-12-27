using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon {
    private Character player;
    public Sword(string name) :base(name)
    {
        UpgradeValues.Attack = 10;
        Type = ItemType.WEAPON;

        player = GameManager.GetCharacterManager().GetPlayer();
    }
    private float _offset = 1.0f;
    private Vector3 _halfSize = new Vector3(1f, 0.5f, 0.5f);


    public override void Activate()
    {
        // attack
        Collider[] allOverlappingColliders = Physics.OverlapBox(player.CharacterObject.transform.position + (player.CharacterObject.transform.forward *_offset), _halfSize);
        
        foreach (Collider collider in allOverlappingColliders)
        {
            if(collider.gameObject.tag == "Enemy")
            {
                collider.gameObject.GetComponent<VisualCharacter>().Character.TakeDamage(player.AttackPower);
            }
        }
    }

}
