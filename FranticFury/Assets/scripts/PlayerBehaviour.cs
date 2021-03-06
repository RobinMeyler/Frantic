﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{ 
    // What is the maximum speed we want to walk at
    private float maxSpeed = 5f;

    // Start facinf left (like the sprite-sheet)
    private bool facingLeft = false;

    // This will be a reference to the RigidBody2D 
    // component in the Player object
    private Rigidbody2D rb;

    // This is a reference to the Animator component
    private Animator anim;

    private float time = 0f;
    public GameObject controller;
    public bool die = false;
    public float powerUpResestTimer = 0;

    private bool touchingWall = false;

    // We initialize our two references in the Start method
    void Start()
    {
        die = false;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        GameObject[] ballers;
        ballers = GameObject.FindGameObjectsWithTag("Platform");
        int index = 0;
        foreach (GameObject plat in ballers)
        {
            if (index == 2 && SceneManager.GetActiveScene().name == "FranticFury")
            {
                transform.position = plat.transform.position + new Vector3(0, 0.75f, 0);
            }
            index++;
        }
    }

    // We use FixedUpdate to do all the animation work
    void FixedUpdate()
    {
        time += Time.deltaTime;
        powerUpResestTimer -= Time.deltaTime;

        if(powerUpResestTimer <= 0)
        {
            GameController.playerSpeed = 0.5f;
        }
        // Get the extent to which the player is currently pressing left or right
        float h = Input.GetAxis("Horizontal");

        // Move the RigidBody2D (which holds the player sprite)
        // on the x axis based on the stae of input and the maxSpeed variable
        //rb.velocity = new Vector2(h * maxSpeed, rb.velocity.y);

        // Pass in the current velocity of the RigidBody2D
        // The speed parameter of the Animator now knows
        // how fast the player is moving and responds accordingly
        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));


        // Check which way the player is facing 
        // and call reverseImage if neccessary
        //if (h < 0 && !facingLeft)
        //    reverseImage();
        //else if (h > 0 && facingLeft)
        //    reverseImage();

        if (rb.velocity.x < 0 && !facingLeft)
            reverseImage();
        else if (rb.velocity.x > 0 && facingLeft)
            reverseImage();

        checkKeyInput();

        if (anim.GetBool("jump"))
        {
            if (time > 0.5)
            {
                anim.SetBool("jump", false);
            }
        }
        if (transform.position.y < -4 )
        {
            GameController.gameTime = 0;
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }

        if (die)
        {
            if (SceneManager.GetActiveScene().name == "Tutorial")
            {
                this.gameObject.SetActive(false);
                transform.position = new Vector3(-2.43f, -2.16f, 0);
                this.gameObject.SetActive(true);
                die = false;
            }
        }

    }

    void reverseImage()
    {
        // Switch the value of the Boolean
        facingLeft = !facingLeft;

        // Get and store the local scale of the RigidBody2D
        Vector2 theScale = rb.transform.localScale;

        // Flip it around the other way
        theScale.x *= -1;
        rb.transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform") //&& collision.transform.position.y > this.transform.position.y)
        {
            anim.SetBool("grounded", true);
            transform.SetParent(collision.transform);
        }
        if (collision.gameObject.tag == "Border")
        {
            touchingWall = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PowerUp") //&& collision.transform.position.y > this.transform.position.y)
        {
            GameController.playerSpeed = 0.65f;
            powerUpResestTimer = 3;
            collision.gameObject.SetActive(false);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            transform.parent = null;
        }
        if (collision.gameObject.tag == "Border")
        {
            touchingWall = false;
        }
    }
    
    void checkKeyInput()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
        {
            if (!anim.GetBool("jump") && anim.GetBool("grounded"))
            {
                if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") || anim.GetCurrentAnimatorStateInfo(0).IsName("Walking")) // == "Idle" || anim.name == "Walking")
                {
                    anim.SetBool("grounded", false);
                    anim.SetBool("jump", true);
                    time = 0;
                    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + 6);
                }
            }
        }
    }

    public void buttonJump()
    {
        if ((!anim.GetBool("jump") && anim.GetBool("grounded")) || (touchingWall && !anim.GetBool("jump")))
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") || anim.GetCurrentAnimatorStateInfo(0).IsName("Walking")) // == "Idle" || anim.name == "Walking")
            {
                anim.SetBool("grounded", false);
                anim.SetBool("jump", true);
                time = 0;
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + GameController.playerSpeed*12);
            }
        }
    }
}
