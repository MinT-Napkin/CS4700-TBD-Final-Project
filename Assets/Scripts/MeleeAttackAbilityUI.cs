using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeleeAttackAbilityUI : AbilityUI
{
    public override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        keyInput = playerClass.meleeWeapon.inputKey;
        cooldown = playerClass.meleeWeapon.attackCooldown;
    }

    public override void Update()
    {
        base.Update();
        setCooldown(playerClass.meleeWeapon.attackCooldown);
    }
}
