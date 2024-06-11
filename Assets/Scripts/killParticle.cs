using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killParticle : MonoBehaviour
{
    
    public float projectileLifetime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, projectileLifetime);
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyBullet") || collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Boss") )
        {
            Destroy(gameObject);
        }
    }
}
