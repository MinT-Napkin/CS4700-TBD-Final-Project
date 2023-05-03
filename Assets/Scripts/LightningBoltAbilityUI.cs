using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightningBoltAbilityUI : AbilityUI
{
    public override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        cooldown = playerClass.lightningBolt.attackCooldown;
    }

    public override void Update()
    {
        base.Update();
        setCooldown(playerClass.lightningBolt.attackCooldown);
    }
}
