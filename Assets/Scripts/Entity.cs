using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour{
    public EntityStats entityStats;

    void DamageHealth(float finalDamage){
        entityStats.currentHealth -= finalDamage;

        if (entityStats.currentHealth == 0){
            entityStats.normalizedHealth = (entityStats.currentHealth / entityStats.maxHealth);

            OnEntityDeath();
        }
        else if (entityStats.currentHealth < 0){
            entityStats.currentHealth = 0;

            entityStats.normalizedHealth = (entityStats.currentHealth / entityStats.maxHealth);

            OnEntityDeath();
        }
    }

    protected virtual void OnEntityDeath(){
        //death animation or whatever happens onbeng defeated
    }

    public void TakeDamage(DamageEvent damageEvent) {
        float finalDamage;

        finalDamage = damageEvent.ApplyDamage();

        DamageHealth(finalDamage);
    }
}