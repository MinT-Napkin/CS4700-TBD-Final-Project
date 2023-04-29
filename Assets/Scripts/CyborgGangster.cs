using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CyborgGangster : EnemyRanged
{
    public override void RangedAttack()
    {
        base.RangedAttack();
        Debug.Log("Cyborg gangster shoots!");
    }
}

