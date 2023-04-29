using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : Entity{

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

    public virtual void Awake()
    {
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
    }

    public virtual void Update()
    {
        healthbar.SetHealth(entityStats.currentHealth, entityStats.maxHealth);
        distance = Vector2.Distance(target.position, transform.position);
    }

    protected override void OnEntityDeath(){
        entityStats.walkSpeed = 0f;
        enemyRespawner.Respawn((GameObject)Resources.Load("prefabs/specific enemies/" + name + " Variant"), respawnPosition, respawnRotation, respawnTime);
        Destroy(gameObject);
    }

    public void RotateEnemy()
    {
        Vector2 direction = target.position - transform.position;
        direction.Normalize();
        if (!freezeRotation)
        {
            if (direction.y < -0.5f)
                transform.eulerAngles = new Vector3(0f, 0f, 180f);
            else if (direction.y > 0.5f)
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
            else if (direction.x < 0)
                transform.eulerAngles = new Vector3(0f, 0f, 90f);
            else if (direction.x > 0)
                transform.eulerAngles = new Vector3(0f, 0f, -90f);
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
