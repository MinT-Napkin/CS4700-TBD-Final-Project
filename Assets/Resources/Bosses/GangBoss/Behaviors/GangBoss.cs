using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GangBoss : Boss
{
    public override void Awake()
    {
        //Add more here
        base.Awake();
        entityStats.walkSpeed = 2f;
    }

    public override void Update()
    {
        base.Update();
    }

    protected override void OnEntityDeath()
    {
        //Unlock flamethrower
        base.OnEntityDeath();
    }

    public override void RotateEvent()
    {
        base.RotateEvent();
        attackPoint.localPosition = new Vector2(-0.082f, -0.039f);
    }

    public override void SetAttackPointDownEvent()
    {
        attackPoint.localPosition = new Vector2(0.021f, -0.167f);
    }

    public override void SetAttackPointUpEvent()
    {
        attackPoint.localPosition = new Vector2(0.013f, 0.079f);
    }

    public override void MeleeAttackEvent()
    {
        Debug.Log("GangBoss attacks!");
    }
}
