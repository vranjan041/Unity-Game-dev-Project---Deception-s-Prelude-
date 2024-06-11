using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject player;

    public GameObject EbulletPrefab;

    public float bulletSpeed = 5f;
    public float Hp = 50f;

    public float fireRate = 0.5f;

    private float nextFireTime = 0f;

    public float explosionLifetime = 0.5f;

    public GameObject explosionPrefab;



    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Hp -= 25f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Hp <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            // Destroy(explosionPrefab, explosionLifetime);
        }
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        if(Time.time > nextFireTime)
        {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        Shoot(direction);
        nextFireTime = Time.time + 1f/fireRate;
        }
        
    }

    void Shoot(Vector3 direction)
    {
        // Instantiate a bullet at the player's position and shoot in the specified direction
        GameObject bullet = Instantiate(EbulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed; // Adjust speed as needed
    }
}
