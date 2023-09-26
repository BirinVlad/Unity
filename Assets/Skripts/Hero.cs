using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
    public float fastspeed = 6.0f;
    private float realspeed;
    public float speed = 1.0f;
    public float jumpForce = 5.0f;
    Rigidbody2D rb;
    SpriteRenderer sr;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        realspeed = speed;
    }

    void Update()
    {
        Walk();
        Run();
        Jump();


    }
    void Walk()
    {
        float movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * realspeed * Time.deltaTime;
        sr.flipX = movement < 0 ? true : false;
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.05f)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        ;

    }
    void Run ()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            realspeed = fastspeed;
        }
        else
        {
            realspeed = speed;
        }



    }
}
