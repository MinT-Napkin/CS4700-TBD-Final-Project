using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlamethrowerAbilityUI : AbilityUI
{
    public override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        keyInput = playerClass.flamethrower.inputKey;
        cooldown = playerClass.flamethrower.attackCooldown;
    }

    public override void Update()
    {
        base.Update();
        setCooldown(playerClass.flamethrower.attackCooldown);
    }
}
