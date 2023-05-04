using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Entity
{
    public LayerMask targetLayer;
    public Transform target;
    public float distance;
    public Vector2 direction;
    public Rigidbody2D rb2d;
    public float initiateRange;
    public float meleeAttackRange;
    public Transform attackPoint;
    public Animator animator;

    public override void Awake()
    {
        base.Awake();
        targetLayer = LayerMask.GetMask("Player");
        target = GameObject.FindWithTag("Player").transform;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    public virtual void Update()
    {
        direction = target.position - transform.position;
        direction.Normalize();
        distance = Vector2.Distance(target.position, transform.position);
    }

    protected override void OnEntityDeath()
    {
        //Add more here
        Destroy(gameObject);
    }

    void StartBossfight()
    {}

    void EndBossfight()
    {}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, initiateRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, meleeAttackRange);
    }

    public virtual void RotateEvent()
    {
        if (direction.x < -0.6)
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        else if (direction.x > 0.6)
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
    }

    public virtual void SetAttackPointDownEvent()
    {

    }

    public virtual void SetAttackPointUpEvent()
    {

    }

    public virtual void MeleeAttackEvent()
    {

    }
}
