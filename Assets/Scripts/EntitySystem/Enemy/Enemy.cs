using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : Entity{

    public List<EnemyDroppedItem> droppedItems = new List<EnemyDroppedItem>();

    public EnemyHealthbar healthbar;

    new public string name;
    public EnemyRespawner enemyRespawner;
    public float respawnTime;
    public Vector3 respawnPosition;
    public Quaternion respawnRotation;

    public Transform attackPoint;
    public Transform target;
    public LayerMask targetLayer;

    public float chaseRange;
    public float distance;

    protected bool freezeRotation = false;

    protected Pathfinding.AIDestinationSetter aiDestinationSetter;
    protected Pathfinding.AIPath aiPath;

    public Vector2 direction;

    public Animator animator;

    public SpriteRenderer spriteRenderer;

    public override void Awake(){
        healthbar = transform.GetChild(1).gameObject.GetComponent<EnemyHealthbar>();
        healthbar.offset = Vector3.up;
        enemyRespawner = GameObject.FindWithTag("Enemy Respawner").GetComponent<EnemyRespawner>();
        target = GameObject.FindWithTag("Player").transform;
        targetLayer = LayerMask.GetMask("Player");
        aiDestinationSetter = gameObject.GetComponent<Pathfinding.AIDestinationSetter>();
        aiDestinationSetter.target = target;
        aiPath = gameObject.GetComponent<Pathfinding.AIPath>();
        aiPath.maxSpeed = entityStats.walkSpeed;
        aiPath.canMove = false;
        respawnPosition = gameObject.transform.position;
        respawnRotation = gameObject.transform.rotation;
        animator = gameObject.GetComponent<Animator>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public virtual void Update(){
        direction = target.position - transform.position;
        direction.Normalize();
        distance = Vector2.Distance(target.position, transform.position);
        RotateEnemy();
        healthbar.SetHealth(entityStats.currentHealth, entityStats.maxHealth);
    }

    protected override void OnEntityDeath(){
        SoundManager.instance.PlaySound(SoundManager.instance.enemyDeathSound);
        enemyRespawner.Respawn((GameObject)Resources.Load("prefabs/specific enemies/" + name + " Variant"), respawnPosition, respawnRotation, respawnTime);
        DropItems();
        target.gameObject.GetComponent<Entity>().entityStats.currentExperiencePoints += 10;
        Destroy(gameObject);
    }

    void DropItems(){
        int dropCount;

        foreach (EnemyDroppedItem itemToDrop in droppedItems){
            dropCount = 0;

            for (int i = 0; i < itemToDrop.maxDropCount; i++){
                if (Random.Range(0f, 100f) <= itemToDrop.dropRate){
                    dropCount++;
                }
            }

            if (dropCount > 0){
                Instantiate(itemToDrop.item, transform.position, transform.rotation);
            }
        }
    }

    public void RotateEnemy(){
        bool isFacingRight;
        bool isFacingLeft;
        bool isFacingUp;
        bool isFacingDown;

        if (!freezeRotation){
            if (direction.y < -0.5f){
                //transform.eulerAngles = new Vector3(0f, 0f, 180f);
                Debug.Log("down");
                isFacingUp = false;
                isFacingDown = true;
                isFacingLeft = false;
                isFacingRight = false;
                animator.SetBool("isFacingUp", isFacingUp);
                animator.SetBool("isFacingDown", isFacingDown);
                animator.SetBool("isFacingLeft", isFacingLeft);
                animator.SetBool("isFacingRight", isFacingRight);
                spriteRenderer.flipX = false;

                attackPoint.localPosition = new Vector2(0,-0.153999999f);
            }   
            else if (direction.y > 0.5f){
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
                Debug.Log("up");
                isFacingDown = false;
                isFacingUp = true;
                isFacingLeft = false;
                isFacingRight = false;
                animator.SetBool("isFacingUp", isFacingUp);
                animator.SetBool("isFacingDown", isFacingDown);
                animator.SetBool("isFacingLeft", isFacingLeft);
                animator.SetBool("isFacingRight", isFacingRight);
                spriteRenderer.flipX = false;

                attackPoint.localPosition = new Vector2(0,0.258f);
            }
            else if (direction.x < 0) {
                //transform.eulerAngles = new Vector3(0f, 0f, 90f);
                Debug.Log("left");
                isFacingLeft = true;
                isFacingRight = false;
                isFacingUp = false;
                isFacingDown = false;
                animator.SetBool("isFacingUp", isFacingUp);
                animator.SetBool("isFacingDown", isFacingDown);
                animator.SetBool("isFacingLeft", isFacingLeft);
                animator.SetBool("isFacingRight", isFacingRight);
                spriteRenderer.flipX = false;

                attackPoint.localPosition = new Vector2(-0.239f, -.006f);
            }
            else if (direction.x > 0){
                //transform.eulerAngles = new Vector3(0f, 0f, -90f);
                Debug.Log("right");
                isFacingRight = true;
                isFacingLeft = false;
                isFacingUp = false;
                isFacingDown = false;

                animator.SetBool("isFacingUp", isFacingUp);
                animator.SetBool("isFacingDown", isFacingDown);
                animator.SetBool("isFacingLeft", isFacingLeft);
                animator.SetBool("isFacingRight", isFacingRight);
                spriteRenderer.flipX = true;

                attackPoint.localPosition = new Vector2(0.239f, -0.006f);
            }
        }
        


    }


}
