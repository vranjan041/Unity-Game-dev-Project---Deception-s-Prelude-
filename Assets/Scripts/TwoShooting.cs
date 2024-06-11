using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoShooting : MonoBehaviour
{
    private float nextFireTime = 0f;

    private float currentFireRate = 2.5f;

    public GameObject bulletPrefab;

    public float bulletSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleShooting();
    }

    void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextFireTime) // Assuming left mouse button for shooting
        {

            Vector3 shootDirection = GetShootDirection();

            Shoot(shootDirection);

            nextFireTime = Time.time + 1f / currentFireRate;
        }
    }

    void Shoot(Vector3 direction)
    {
        // Instantiate a bullet at the fire point and shoot in the specified direction
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }

    Vector3 GetShootDirection()
    {
        // Determine the direction based on the character's facing direction
        float facingDirection = Mathf.Sign(transform.localScale.x);

        // Create a vector pointing in the facing direction
        Vector3 shootDirection = new Vector3(facingDirection, 0f, 0f);

        return shootDirection;
    }
}
