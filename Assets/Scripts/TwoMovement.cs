using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TwoMovement : MonoBehaviour
{
    public Rigidbody2D body;

    public float speed = 8f;

    private bool grounded;

    public float jumpPower = 10f;

    public GameObject Speedorb;

    public GameObject HealthOrb;

    private float currentSpeed;

    public float Hp = 300f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(Hp <= 0f)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput* currentSpeed, body.velocity.y);

        if(horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(1.888436f,1.888436f,1.888436f);
        }
        else if(horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1.888436f,1.888436f,1.888436f);
        }

        if(Input.GetKey(KeyCode.Space) && grounded)
        {
            Jump();
        }
        
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpPower);
        grounded = false;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Obstacle")
        {
            grounded = true;
        }
        if (collision.gameObject.CompareTag("BlueOrb"))
        {
            StartCoroutine(Boostspeed(5f));
            Destroy(Speedorb);
        }
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Hp -= 100f;
        }
        if(collision.gameObject.CompareTag("EnemyBullet"))
        {
            Hp -= 25f;
        }
        if(collision.gameObject.CompareTag("GreenOrb"))
        {
            if(Hp+200f <= 300f)
            Hp += 200f;
            else
            Hp = 300f;
            Destroy(HealthOrb);
        }
    }

    IEnumerator Boostspeed(float boostDuration)
    {
        // Increase the fire rate during the boost
        currentSpeed = speed * 2f;

        // Wait for the specified boost duration
        yield return new WaitForSeconds(boostDuration);

        // Reset the fire rate to the base value after the boost duration
        currentSpeed = speed;
    }
}
