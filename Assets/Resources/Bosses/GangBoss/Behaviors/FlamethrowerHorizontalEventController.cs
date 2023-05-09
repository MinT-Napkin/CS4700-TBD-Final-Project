using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerHorizontalEventController : MonoBehaviour
{
    public GangBoss boss;
    public Quaternion originalRotation;
    public Quaternion originalRotationLeft;
    public Quaternion originalRotationRight;

    void Awake()
    {
        boss = transform.parent.gameObject.GetComponent<GangBoss>();
        originalRotationLeft = new Quaternion(0.00000f, 0.00000f, -0.20071f, 0.97965f);
        originalRotationRight = new Quaternion(0.00000f, 0.00000f, -0.97269f, 0.23211f);
    }

    public void SetRotation()
    {
        if (boss.transform.rotation.y == -1)
            boss.flamethrowerHorizontalAttackPoint.rotation = originalRotationRight;
        else
            boss.flamethrowerHorizontalAttackPoint.rotation = originalRotationLeft;
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
        boss.flamethrowerHorizontalAttackPoint.rotation = originalRotation;
    }
}
