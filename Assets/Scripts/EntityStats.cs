using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct EntityStats{
    public EntityStats(string thisIsTheDefaultConstructor){
        attackSpeed = 1.0f;
        currentHealth = 100.0f;
        dashDistance = 20.0f;
        maxHealth = 100.0f;
        normalizedHealth = 1.0f;
        runSpeed = 20.0f;
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
    public float currentHealth;
    public float dashDistance;
    public float maxHealth;
    public float normalizedHealth;
    public float runSpeed;
    public float walkSpeed;
}
