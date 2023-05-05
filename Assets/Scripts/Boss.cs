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
    public float rangedAttackRange;
    public float rangedAttackCooldown;
    public bool rangedAttackOnCooldown = false;
    public Transform attackPoint;
    public Transform rangedAttackPoint;
    public Animator animator;

    public int phase;

    public override void Awake()
    {
        base.Awake();
        targetLayer = LayerMask.GetMask("Player");
        target = GameObject.FindWithTag("Player").transform;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        phase = 1;
    }

    public virtual void Update()
    {
        direction = target.position - transform.position;
        direction.Normalize();
        distance = Vector2.Distance(target.position, transform.position);

        if ((entityStats.normalizedHealth <= 0.5f) && (phase < 2))
        {
            animator.SetTrigger("PhaseTransition");
            phase = 2;
            //Boost entityStats
        }
    }

    protected override void OnEntityDeath()
    {
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
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, rangedAttackRange);
    }

    public virtual void RotateEvent()
    {
        if (direction.x < -0.5)
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        else if (direction.x >= 0.5)
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

    public virtual void RangedAttackEvent()
    {

    }

    public void ResetPhaseTransitionTriggerEvent()
    {
        animator.ResetTrigger("PhaseTransition");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
            entityStats.normalizedHealth -= 0.1f;
            Destroy(other.gameObject);
        }
    }
}
