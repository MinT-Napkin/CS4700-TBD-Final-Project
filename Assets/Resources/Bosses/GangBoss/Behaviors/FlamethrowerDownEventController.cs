using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerDownEventController : MonoBehaviour
{
    public GangBoss boss;
    public Quaternion originalRotation;

    void Awake()
    {
        boss = transform.parent.gameObject.GetComponent<GangBoss>();
        originalRotation = boss.flamethrowerDownAttackPoint.rotation;
    }

    public void FlamethrowerEvent()
    {
        boss.FlamethrowerEventDown();
    }

    public void ResetFlamethrower()
    {
        boss.flamethrowerDownAttackPoint.rotation = originalRotation;
    }
}
