using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float movement;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] int speed;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] float jumpForce = 500.0f;
    [SerializeField] bool isGrounded = true;
    [SerializeField] bool shiftPressed = false;

    [SerializeField] GameObject pin;
    [SerializeField] float lastFiredTime = 0;
    [SerializeField] float fireCD = .25f;

    [SerializeField] Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        speed = 15;
        if(pin == null)
            pin = GameObject.FindGameObjectWithTag("Pin");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("roll", movement > 0.01 || movement < -0.01);
        anim.SetBool("jump", !isGrounded);
        
    }

    //called potentially multiple times per frame
    //used for physics & movement
    void FixedUpdate()
    { 
        movement = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.Space) && !jumpPressed && isGrounded) {
            Debug.Log("jumped");
            jumpPressed = true;
        }
        rigid.velocity = new Vector2(movement * speed, rigid.velocity.y);
        if (movement < 0 && isFacingRight || movement > 0 && !isFacingRight)
            Flip();
        if (jumpPressed && isGrounded)
            Jump();
        if(Input.GetButton("Fire1") && Time.time - lastFiredTime > fireCD) {
            Instantiate(pin, transform.position, Quaternion.identity);
            lastFiredTime = Time.time;
        }
    }

    void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        rigid.AddForce(new Vector2(0, jumpForce));
        isGrounded = false;
        jumpPressed = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        if(collision.gameObject.tag == "Death zone") {
            transform.position = new Vector3(0, 0, 0);
        }
    }
    // private void OnTriggerEnter2D(Collider2D collider) {
    //     Debug.Log("Test trigger");
    // }
    public bool right() {
        return isFacingRight;
    }

}
