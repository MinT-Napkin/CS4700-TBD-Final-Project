using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EntityStats{
    public EntityStats(){
        attackSpeed = 1.0f;
        criticalDamage = 2.0f;
        currentHealth = 100.0f;
        dashDistance = 20.0f;
        defense = 10.0f;
        luck = 5.0f;
        maxHealth = 100.0f;
        normalizedHealth = 1.0f;
        runSpeed = 20.0f;
        specialAttack = 10.0f;
        specialDefense = 10.0f;
        strength = 10.0f;
        walkSpeed = 10.0f;
    }

    public EntityStats(float attackSpeed, float currentHealth, float dashDistance, float maxHealth, float normalizedHealth, float runSpeed, float walkSpeed) {
        this.attackSpeed = attackSpeed;
        this.currentHealth = currentHealth;
        this.dashDistance = dashDistance;
        this.maxHealth = maxHealth;
        this.normalizedHealth = normalizedHealth;
        this.runSpeed = runSpeed;
        this.walkSpeed = walkSpeed;
    }

    public float attackSpeed;
    public float criticalDamage;
    public float currentHealth;
    public float dashDistance;
    public float defense;
    public float luck;
    public float maxHealth;
    public float normalizedHealth;
    public float runSpeed;
    public float specialAttack;
    public float specialDefense;
    public float strength;
    public float walkSpeed;
}
