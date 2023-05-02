using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour{
    public EntityStats entityStats;
    public Inventory inventory;

    public virtual void Awake(){
        entityStats = new EntityStats();
        inventory = gameObject.AddComponent<Inventory>();
    }
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
    }

    protected virtual void DamageHealth(float finalDamage){
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
        else if (entityStats.currentHealth > entityStats.maxHealth) {
            entityStats.currentHealth = entityStats.maxHealth;

            entityStats.normalizedHealth = (entityStats.currentHealth / entityStats.maxHealth);
        }
        else {
            entityStats.normalizedHealth = (entityStats.currentHealth / entityStats.maxHealth);
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
