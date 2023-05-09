using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerUpEventController : MonoBehaviour
{
    public GangBoss boss;
    public Quaternion originalRotation;

    void Awake()
    {
        boss = transform.parent.gameObject.GetComponent<GangBoss>();
        originalRotation = boss.flamethrowerUpAttackPoint.rotation;
    }

    public void FlamethrowerEvent()
    {
        boss.FlamethrowerEventUp();
    }

    public void ResetFlamethrower()
    {
        boss.flamethrowerUpAttackPoint.rotation = originalRotation;
    }
}
