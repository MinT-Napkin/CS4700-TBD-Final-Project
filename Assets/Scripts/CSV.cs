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
            Debug.Log(int.Parse(data[13 * (i + 1)]));

            if (int.Parse(data[13 * (i + 1)]) == entity.entityStats.level){
                Debug.Log("Entity is level " + i + "\n ");

                entity.entityStats.attackSpeed = float.Parse(data[14 * (i + 1)]);
                entity.entityStats.criticalDamage = float.Parse(data[15 * (i + 1)]);
                entity.entityStats.criticalHitRate = float.Parse(data[16 * (i + 1)]);
                entity.entityStats.dashDistance = float.Parse(data[17 * (i + 1)]);
                entity.entityStats.defense = float.Parse(data[18 * (i + 1)]);
                entity.entityStats.maxExperiencePoints = int.Parse(data[19 * (i + 1)]);
                entity.entityStats.maxHealth = float.Parse(data[20 * (i + 1)]);
                entity.entityStats.runSpeed = float.Parse(data[21 * (i + 1)]);
                entity.entityStats.specialAttack = float.Parse(data[22 * (i + 1)]);
                entity.entityStats.specialDefense = float.Parse(data[23 * (i + 1)]);
                entity.entityStats.strength = float.Parse(data[24 * (i + 1)]);
                entity.entityStats.walkSpeed = float.Parse(data[25 * (i + 1)]);

                break;
            }
        }
    }


}
