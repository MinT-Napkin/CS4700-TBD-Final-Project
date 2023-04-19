using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EntityStats{
    public EntityStats(){
        currentHealth = 100.0f;
        defense = 10.0f;
        luck = 5.0f;
        maxHealth = 100.0f;
        normalizedHealth = 1.0f;
        specialAttack = 10.0f;
        specialDefense = 10.0f;
        strength = 10.0f;
    }

    public EntityStats(float currentHealth, float maxHealth, float normalizedHealth, float strength, float defense, float specialAttack, float specialDefense, float luck) {
        this.currentHealth = currentHealth;
        this.maxHealth = maxHealth;
        this.normalizedHealth = normalizedHealth;
        this.strength = strength;
        this.defense = defense;
        this.specialAttack = specialAttack;
        this.specialDefense = specialDefense;
        this.luck = luck;
    }

    public float currentHealth;
    public float defense;
    public float luck;
    public float maxHealth;
    public float normalizedHealth;
    public float specialAttack;
    public float specialDefense;
    public float strength;
}
