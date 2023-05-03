using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangedAttackAbilityUI : AbilityUI
{
    public override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        cooldown = playerClass.rangedWeapon.attackCooldown;
    }

    public override void Update()
    {
        base.Update();
        setCooldown(playerClass.rangedWeapon.attackCooldown);
    }
}
