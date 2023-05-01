using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyborgScientist : EnemyMeleeAndRanged
{
    /*
        aiPath.maxSpeed = 0f; and freezeRotation = true/false; are used to stop enemy movement while executing an attack animation
        The cyborg scientist moves at a moderate walking speed. Its attack is a delayed poison aoe initiated at player position.
        Has a moderate chase range. 
        Balancing: adjust entityStats later
    */

    //Leaving coroutine here to demonstrate attack visually
    public override void MeleeAttack()
    {
        base.MeleeAttack();
        StartCoroutine(DemonstrateAttack());
    }

    IEnumerator DemonstrateAttack()
    {
        aiPath.maxSpeed = 0f;
        freezeRotation = true;
        yield return new WaitForSeconds(1.5f);
        GameObject affectedArea = new GameObject();
        affectedArea.transform.position = target.position;
        affectedArea.AddComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load("DebugSprites/Circle");
        affectedArea.transform.localScale = new Vector3(5f, 5f, 0f);
        affectedArea.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f, 155f/255f);
        Collider2D targetHit = Physics2D.OverlapCircle(target.position, meleeAttackRange, targetLayer);
        if (targetHit != null)
            Debug.Log(targetHit.gameObject.name + " hit by CyborgScientist!");
            //Apply poision
        yield return new WaitForSeconds(3f);
        Destroy(affectedArea);
        aiPath.maxSpeed = entityStats.walkSpeed;
        freezeRotation = false;
    }
}
