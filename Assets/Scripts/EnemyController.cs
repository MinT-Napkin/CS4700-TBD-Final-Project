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

    //Testign for flamethrower upgrade 3
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 3f);
    }

    IEnumerator DebugEnemyHitColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    }
}
