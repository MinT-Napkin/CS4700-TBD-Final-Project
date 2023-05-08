using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoombladesAbilityUI : AbilityUI
{
    public override void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        cooldown = playerClass.doomblades.attackCooldown;
    }

    public override void Update()
    {
        base.Update();
        setCooldown(playerClass.doomblades.attackCooldown);
    }
}
