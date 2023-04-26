using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobGangster : Enemy
{
    public override void MeleeAttack()
    {
        base.MeleeAttack();
        Debug.Log("Mob gangster attacks!");
    }

    public override void RangedAttack()
    {
        base.RangedAttack();
        Debug.Log("Mob gangster shoots!");
    }

    public override void OnDrawGizmosSelected()
    {
        base.OnDrawGizmosSelected();
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, meleeAttackRange);
    }
}
