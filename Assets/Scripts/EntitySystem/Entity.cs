using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Entity : MonoBehaviour{
    public EntityStats entityStats;
    public Inventory inventory;
    public bool isPlayerControlled;
    public UnityEngine.TextAsset textAsset;

    public virtual void Awake(){
        entityStats = new EntityStats();
        inventory = gameObject.AddComponent<Inventory>();
    }
    // Start is called before the first frame update
    protected virtual void Start(){
        CSV csv = new CSV(textAsset);

        csv.ReadEntityStats(this);

        DamageTypeHealing damageType = new DamageTypeHealing();
        DamageEvent damageEvent = new DamageEvent(-100.0f, damageType, this, this, false);
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

    public virtual void LevelUp(){
        SoundManager.instance.PlaySound(SoundManager.instance.levelUpSound);
        CSV csv = new CSV(textAsset);

        entityStats.level++;

        csv.ReadEntityStats(this);
    }

    protected virtual void OnEntityDeath(){
        //death animation or whatever happens onbeng defeated
    }

    public void TakeDamage(DamageEvent damageEvent) {
        float finalDamage;
        Color color;

        finalDamage = damageEvent.ApplyDamage();
        color = damageEvent.GetColor();

        StartCoroutine(DamageColorChange(color));

        DamageHealth(finalDamage);
    }

    IEnumerator DamageColorChange(Color color)
    {
        gameObject.GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
