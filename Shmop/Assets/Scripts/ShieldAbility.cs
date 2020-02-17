using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Shield")]
public class ShieldAbility : Ability
{
    private BoxCollider2D bc2D_;

    public override void Initialize(GameObject obj_in_)
    {
        bc2D_ = obj_in_.GetComponent<BoxCollider2D>();

    }

    public override void TriggerAbility()
    {
        this.bc2D_.enabled = false;
    }
}
