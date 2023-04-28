using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : Enemy
{
    public override void MeleeAttack()
    {
        base.MeleeAttack();
        Debug.Log("Test enemy attacks!");
    }

    public override void RangedAttack()
    {
        base.RangedAttack();
        Debug.Log("Test enemy shoots!");
    }
}
