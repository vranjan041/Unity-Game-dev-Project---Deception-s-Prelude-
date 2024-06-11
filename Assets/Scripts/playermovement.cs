using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playermovement : MonoBehaviour
{
    public float Hp = 300f;
    public float baseFireRate = 1.75f;
    private float currentFireRate;

    public GameObject bulletPrefab;
    public GameObject FireRatePrefab;
    public float moveSpeed = 5f;

    public float horizontalInput;
    public float verticalInput;

    private float nextFireTime = 0f;

    public float bulletSpeed = 10f;

    void Start()
    {
        currentFireRate = baseFireRate;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Hp -= 150f;
        }
        else if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Hp -= 50f;
        }
        else if (collision.gameObject.CompareTag("RedOrb"))
        {
            StartCoroutine(BoostFireRate(5f));
            Destroy(FireRatePrefab);
        }
        else if(collision.gameObject.CompareTag("Exit"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void HandleMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Movement Calculation
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0).normalized;
        movement *= moveSpeed * Time.deltaTime;

        transform.position += movement;
    }

    void Update()
    {
        HandleMovement();
        HandleShooting();
        if (Hp <= 0f)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextFireTime) // Assuming left mouse button for shooting
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // Set the z-coordinate to the same as the player

            Vector3 shootDirection = (mousePosition - transform.position).normalized;

            Shoot(shootDirection);

            nextFireTime = Time.time + 1f / currentFireRate;
        }
    }

    void Shoot(Vector3 direction)
    {
        // Vector3 offset = new Vector3(2f,0,0);
        // Instantiate a bullet at the player's position and shoot in the specified direction
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed; // Adjust speed as needed
    }

    IEnumerator BoostFireRate(float boostDuration)
    {
        // Increase the fire rate during the boost
        currentFireRate = baseFireRate * 5f;

        // Wait for the specified boost duration
        yield return new WaitForSeconds(boostDuration);

        // Reset the fire rate to the base value after the boost duration
        currentFireRate = baseFireRate;
    }
}


