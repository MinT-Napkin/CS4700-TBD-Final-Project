using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyborgGangster : Enemy
{
    public override void RangedAttack()
    {
        base.RangedAttack();
        Debug.Log("Cyborg gangster shoots!");
    }
}
