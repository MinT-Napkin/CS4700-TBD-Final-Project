using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CSV{
    public TextAsset text;

    public CSV(TextAsset text){
        this.text = text;
    }

    public void ReadEntityStats(Entity entity){
        string[] data = text.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);
        int tableSize = data.Length / 13;

        for (int i = 0; i < (tableSize - 1); i++){

            if (int.Parse(data[13 * (i + 1)]) == entity.entityStats.level){
                entity.entityStats.attackSpeed = float.Parse(data[(13 * (i + 1)) + 1]);
                entity.entityStats.criticalDamage = float.Parse(data[(13 * (i + 1)) + 2]);
                entity.entityStats.criticalHitRate = float.Parse(data[(13 * (i + 1)) + 3]);
                entity.entityStats.dashDistance = float.Parse(data[(13 * (i + 1)) + 4]);
                entity.entityStats.defense = float.Parse(data[(13 * (i + 1)) + 5]);
                entity.entityStats.maxExperiencePoints = int.Parse(data[(13 * (i + 1)) + 6]);
                entity.entityStats.maxHealth = float.Parse(data[(13 * (i + 1)) + 7]);
                entity.entityStats.runSpeed = float.Parse(data[(13 * (i + 1)) + 8]);
                entity.entityStats.specialAttack = float.Parse(data[(13 * (i + 1)) + 9]);
                entity.entityStats.specialDefense = float.Parse(data[(13 * (i + 1)) + 10]);
                entity.entityStats.strength = float.Parse(data[(13 * (i + 1)) + 11]);
                entity.entityStats.walkSpeed = float.Parse(data[(13 * (i + 1)) + 12]);

                break;
            }
        }
    }

    public void SetEntityLevel(Entity entity, int level){
        if (level <= 30){
            entity.entityStats.level = level;

            ReadEntityStats(entity);
        }
        else{
            Debug.Log("Entity level too high");
        }
    }


}
