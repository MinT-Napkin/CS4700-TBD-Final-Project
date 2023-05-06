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
    public Transform rangedAttackPoint;
    public Animator animator;

    public BossHealthbar healthbar;

    public override void Awake()
    {
        base.Awake();
        targetLayer = LayerMask.GetMask("Player");
        target = GameObject.FindWithTag("Player").transform;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        healthbar.offset = Vector3.up;
    }

    public virtual void Update()
    {
        direction = target.position - transform.position;
        direction.Normalize();
        distance = Vector2.Distance(target.position, transform.position);
        healthbar.SetHealth(entityStats.currentHealth, entityStats.maxHealth);
    }

    protected override void OnEntityDeath()
    {
        animator.SetTrigger("Death");
    }

    public void AfterDeathAnimation()
    {
        Destroy(gameObject);
    }

    void StartBossfight()
    {}

    void EndBossfight()
    {}

    public virtual void RotateEvent()
    {
        if (direction.x < -0.5)
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        else if (direction.x >= 0.5)
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
    }

    public virtual void FixRotationUpDownEvent()
    {
        transform.eulerAngles = Vector3.zero;
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

    public void SetInvincible(){
        GetComponent<Collider2D>().enabled = false;
    }

    public void ResetInvincible(){
        GetComponent<Collider2D>().enabled = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
            DamageHealth(10f);
            Destroy(other.gameObject);
        }
    }
}
