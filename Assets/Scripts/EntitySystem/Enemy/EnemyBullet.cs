using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Enemy enemy;
    public float bulletSpeed;
    public float bulletRange;
    float distanceTraveled;
    Rigidbody2D rb2d;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        distanceTraveled = 0f;
    }

    void Start()
    {
        rb2d.velocity = enemy.direction * bulletSpeed;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, enemy.direction);
    }

    void Update()
    {
        distanceTraveled += (bulletSpeed * Time.deltaTime);
        if (distanceTraveled > bulletRange)
        {
            Destroy(gameObject);
        }
    }
}
