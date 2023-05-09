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
    }

    public virtual void Update(){
        direction = target.position - transform.position;
        direction.Normalize();
        healthbar.SetHealth(entityStats.currentHealth, entityStats.maxHealth);
        distance = Vector2.Distance(target.position, transform.position);
    }

    protected override void OnEntityDeath(){
        enemyRespawner.Respawn((GameObject)Resources.Load("prefabs/specific enemies/" + name + " Variant"), respawnPosition, respawnRotation, respawnTime);
        DropItems();
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
                isFacingUp = true;
                isFacingDown = false;
                animator.SetBool("isFacingUp", isFacingUp);
            }
            else if (direction.y > 0.5f){
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
                Debug.Log("up");
                isFacingDown = true;
                isFacingUp = false;
                animator.SetBool("isFacingDown", isFacingDown);
            }
            else if (direction.x < 0) {
                //transform.eulerAngles = new Vector3(0f, 0f, 90f);
                Debug.Log("left");
                isFacingLeft = true;
                isFacingRight = false;
                animator.SetBool("isFacingLeft", isFacingLeft);
            }
            else if (direction.x > 0){
                //transform.eulerAngles = new Vector3(0f, 0f, -90f);
                Debug.Log("right");
                isFacingRight = true;
                isFacingLeft = false;
                animator.SetBool("isFacingRight", isFacingRight);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bullet")
        {
            Debug.Log(gameObject.name + " hit with player bullet!");
            Destroy(other.gameObject);
        }
    }


}
