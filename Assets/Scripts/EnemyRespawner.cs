using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawner : MonoBehaviour
{
    public void Respawn(GameObject enemyPrefab, Vector3 position, Quaternion rotation, float respawnTime)
    {
        StartCoroutine(RespawnTimer(enemyPrefab, position, rotation, respawnTime));
    }

    IEnumerator RespawnTimer(GameObject enemyPrefab, Vector3 position, Quaternion rotation, float respawnTime)
    {
        Debug.Log(enemyPrefab.name + " will respawn at " + position);
        yield return new WaitForSeconds(respawnTime);
        Instantiate(enemyPrefab, position, rotation);
    }
}
