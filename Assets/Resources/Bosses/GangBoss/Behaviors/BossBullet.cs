using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public Boss boss;
    public Vector2 direction;
    public float bulletSpeed;
    public float bulletRange;
    float distanceTraveled;
    Rigidbody2D rb2d;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        distanceTraveled = 0f;
        direction = boss.target.position - transform.position;
        direction.Normalize();
    }

    void Start()
    {
        rb2d.velocity = direction * bulletSpeed;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, boss.direction);
    }

    void Update()
    {

        distanceTraveled += (bulletSpeed * Time.deltaTime);
        if (distanceTraveled > bulletRange + 10f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Damage
            Destroy(gameObject);
        }
    }
}
