using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossObstacle : MonoBehaviour
{
    public GameObject bossObstacle;
    public void spawnBossObstacle(){
        bossObstacle.SetActive(true);
    }

    public void despawnBossObstacle(){
        bossObstacle.SetActive(false);
    }
}
