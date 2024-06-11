using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BossShooting : MonoBehaviour
{
    public GameObject player;

    public GameObject EbulletPrefab;

    public float bulletSpeed = 10f;
    public float Hp = 600f;

    public float fireRate = 0.5f;

    private float nextFireTime = 0f;

    public float explosionLifetime = 0.5f;

    // public GameObject explosionPrefab;



    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            Hp -= 50f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Hp <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
        if(Hp >= 300)
        {
        // Instantiate a bullet at the player's position and shoot in the specified direction
        GameObject bullet = Instantiate(EbulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        GameObject bullet2 = Instantiate(EbulletPrefab, transform.position, Quaternion.identity);
        bullet2.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        GameObject bullet3 = Instantiate(EbulletPrefab, transform.position, Quaternion.identity);
        bullet3.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        GameObject bullet4 = Instantiate(EbulletPrefab, transform.position, Quaternion.identity);
        bullet4.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;} // Adjust speed as needed
        else
        {
        Vector3 offset = new Vector3(1f,1f, 0f );
        GameObject bullet5 = Instantiate(EbulletPrefab, transform.position + offset, Quaternion.identity);
        bullet5.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        GameObject bullet6 = Instantiate(EbulletPrefab, transform.position + offset, Quaternion.identity);
        bullet6.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        GameObject bullet7 = Instantiate(EbulletPrefab, transform.position + offset, Quaternion.identity);
        bullet7.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        GameObject bullet8 = Instantiate(EbulletPrefab, transform.position + offset, Quaternion.identity);
        bullet8.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }
    }
}
