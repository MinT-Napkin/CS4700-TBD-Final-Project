using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawner : MonoBehaviour
{
    public void Respawn(GameObject enemyPrefab, Transform location, float respawnTime)
    {
        StartCoroutine(RespawnTimer(enemyPrefab, location, respawnTime));
    }

    IEnumerator RespawnTimer(GameObject enemyPrefab, Transform location, float respawnTime)
    {
        yield return new WaitForSeconds(respawnTime);
        Instantiate(enemyPrefab, location);
    }
}
