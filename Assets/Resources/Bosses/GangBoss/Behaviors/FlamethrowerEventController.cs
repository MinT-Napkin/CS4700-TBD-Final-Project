using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerEventController : MonoBehaviour
{
    public GangBoss boss;
    public Quaternion originalRotation;
    public Quaternion originalRotationLeft;
    public Quaternion originalRotationRight;

    void Awake()
    {
        boss = transform.parent.gameObject.GetComponent<GangBoss>();
        originalRotation = boss.flamethrowerAttackPoint.rotation;
        originalRotationLeft = originalRotation;
        originalRotationRight = new Quaternion(boss.flamethrowerAttackPoint.rotation.x, boss.flamethrowerAttackPoint.rotation.y, boss.flamethrowerAttackPoint.rotation.z - 3.5f, boss.flamethrowerAttackPoint.rotation.w);
    }

    public void FlamethrowerEvent()
    {
        if (boss.transform.rotation.y == -1)
        {
            originalRotation = originalRotationRight;
            boss.FlamethrowerEventRight();
        }
        else
        {
            originalRotation = originalRotationLeft;
            boss.FlamethrowerEventLeft();
        }
    }

    public void ResetFlamethrower()
    {
        boss.flamethrowerAttackPoint.rotation = originalRotation;
    }
}
