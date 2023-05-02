using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EntityStats{
    public EntityStats(){
        
        attackSpeed = 0.0f;
        criticalDamage = 0.0f;
        criticalHitRate = 0.0f;
        currentHealth = 0.0f;
        dashDistance = 0.0f;
        defense = 0.0f;
        maxHealth = 0.0f;
        normalizedHealth = 0.0f;
        runSpeed = 0.0f;
        specialAttack = 0.0f;
        specialDefense = 0.0f;
        strength = 0.0f;
        walkSpeed = 0.0f;

    }

    public EntityStats(float attackSpeed, float criticalDamage, float criticalHitRate, float currentHealth, float dashDistance, float defense, float maxHealth, float normalizedHealth, float runSpeed, float specialAttack, float specialDefense, float strength, float walkSpeed) {
        this.attackSpeed = attackSpeed;
        this.criticalDamage = criticalDamage;
        this.criticalHitRate = criticalHitRate;
        this.currentHealth = currentHealth;
        this.dashDistance = dashDistance;
        this.defense = defense;
        this.maxHealth = maxHealth;
        this.normalizedHealth = normalizedHealth;
        this.runSpeed = runSpeed;
        this.specialAttack = specialAttack;
        this.specialDefense = specialDefense;
        this.strength = strength;
        this.walkSpeed = walkSpeed;
    }

    public float attackSpeed;
    public float criticalDamage;
    public float criticalHitRate;
    public float currentHealth;
    public float dashDistance;
    public float defense;
    public float maxHealth;
    public float normalizedHealth;
    public float runSpeed;
    public float specialAttack;
    public float specialDefense;
    public float strength;
    public float walkSpeed;
}
