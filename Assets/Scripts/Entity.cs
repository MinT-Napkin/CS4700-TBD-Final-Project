using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour{
    public EntityStats entityStats;

    void Awake(){
        entityStats = new EntityStats();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
    }

    public void TakeDamage(DamageEvent damageEvent){
        float finalDamage;

        finalDamage = damageEvent.ApplyDamage();

        DamageHealth(finalDamage);
    }

    void DamageHealth(float finalDamage){
        entityStats.currentHealth -= finalDamage;

        if (entityStats.currentHealth < 0){
            entityStats.currentHealth = 0;
        }

        entityStats.normalizedHealth = (entityStats.currentHealth / entityStats.maxHealth);
    }
}
