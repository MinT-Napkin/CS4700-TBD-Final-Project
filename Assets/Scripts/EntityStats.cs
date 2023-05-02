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
        currentExperiencePoints = 0;
        currentHealth = 0.0f;
        dashDistance = 0.0f;
        defense = 0.0f;
        level = 0;
        maxExperiencePoints = 0;
        maxHealth = 0.0f;
        normalizedHealth = 0.0f;
        runSpeed = 0.0f;
        specialAttack = 0.0f;
        specialDefense = 0.0f;
        strength = 0.0f;
        walkSpeed = 0.0f;
    }

    public EntityStats(float attackSpeed, float criticalDamage, float criticalHitRate, int currentExperiencePoints, float currentHealth, float dashDistance, float defense, int level, int maxExperiencePoints, float maxHealth, float normalizedHealth, float runSpeed, float specialAttack, float specialDefense, float strength, float walkSpeed) {
        this.attackSpeed = attackSpeed;
        this.criticalDamage = criticalDamage;
        this.criticalHitRate = criticalHitRate;
        this.currentHealth = currentHealth;
        this.currentExperiencePoints = currentExperiencePoints;
        this.dashDistance = dashDistance;
        this.defense = defense;
        this.level = level;
        this.maxExperiencePoints = maxExperiencePoints;
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
    public int currentExperiencePoints;
    public float currentHealth;
    public float dashDistance;
    public float defense;
    public int level;
    public int maxExperiencePoints;
    public float maxHealth;
    public float normalizedHealth;
    public float runSpeed;
    public float specialAttack;
    public float specialDefense;
    public float strength;
    public float walkSpeed;
}
