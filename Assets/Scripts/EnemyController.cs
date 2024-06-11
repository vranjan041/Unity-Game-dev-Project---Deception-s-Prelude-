using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    public GameObject player;
    public GameObject explosionPrefab;
    public float movementSpeed = 5f;
    public float hp = 100f;

    public float explosionLifetime = 1f;

    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            hp -= 25f;
        }
    }

   

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0f)
        {
            Destroy(gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            // Destroy(explosionPrefab, explosionLifetime);
        }

       
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, movementSpeed* Time.deltaTime);
        // transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }

    
}
