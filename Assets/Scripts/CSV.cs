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
                //Debug.Log("Entity is level " + i + "\n " + float.Parse(data[13 * ((i + 1) + 1)]) + " " + float.Parse(data[13 * (i + 1) + 1]));

                entity.entityStats.attackSpeed = float.Parse(data[13 * ((i + 1) + 1)]);
                entity.entityStats.criticalDamage = float.Parse(data[13 * ((i + 1) + 2)]);
                entity.entityStats.criticalHitRate = float.Parse(data[13 * ((i + 1) + 3)]);
                entity.entityStats.dashDistance = float.Parse(data[13 * ((i + 1) + 4)]);

                break;
            }
        }
    }


}
