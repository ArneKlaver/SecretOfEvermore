using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : Weapon
{
    private Character player;
    public Spear(string name) : base(name)
    {
        UpgradeValues.Attack = 10;
        Type = ItemType.WEAPON;
        Range = 20;
        player = GameManager.GetCharacterManager().GetPlayer();
    }

    public override void Activate()
    {
        // raycast and do damage to the first enemy that gets hit
        RaycastHit hit;
        if (Physics.Raycast(player.CharacterObject.transform.position, player.CharacterObject.transform.forward, out hit, Range))
        {
            if (hit.transform.gameObject.tag == "Enemy")
            {
                hit.transform.gameObject.GetComponent<VisualCharacter>().Character.TakeDamage(player.AttackPower);
            }
        }
    }
}
