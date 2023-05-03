using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldAbilityUI : AbilityUI
{
    public override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        cooldown = playerClass.shield.attackCooldown;
    }

    public override void Update()
    {
        base.Update();
        setCooldown(playerClass.shield.attackCooldown);
    }
}
