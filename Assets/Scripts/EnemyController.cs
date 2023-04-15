using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
            StartCoroutine(DebugEnemyHitColor());
            Destroy(other.gameObject);
        }
    }

    IEnumerator DebugEnemyHitColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }
}
