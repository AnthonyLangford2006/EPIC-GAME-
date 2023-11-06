using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Unit1Assignment : MonoBehaviour
{
    Animator anim;
    SpriteRenderer sr;
    Rigidbody2D rb;
    Helper helper;
    public GameObject weapon;
    int speed;
    bool isJumping;
   

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        helper = gameObject.AddComponent<Helper>();

        speed = 1;
        isJumping = false;

    }

    // Update is called once per frame
    void Update()
    {
        
        anim.SetBool("Run", false);
        

        DoRun();
        DoJump();
        DoAttack();
        DoLand();




    }

    void DoRun()
    {
        if (Input.GetKey("a") == true)
        {

            transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
            anim.SetBool("Run", true);
            sr.flipX = true;

        }


        if (Input.GetKey("d") == true)
        {

            transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
            anim.SetBool("Run", true);
            sr.flipX = false;
        }
    }



    void DoJump()
    {

        int jumpAmount = 2;

        if (helper.ExtendedRayCollisionCheck(0, 0.1f) == true)
        {
            if (Input.GetKeyDown("w"))
            {
                rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
                anim.SetBool("Jump", true);
                isJumping = true;
            }
        }
    }


    void DoAttack()
    {
        if (Input.GetKeyDown("q"))
        {
            print("player pressed attack");
            anim.SetTrigger("Attack1");
           
        }

        int moveDirection = 1;
        if (Input.GetButtonDown("Fire1"))
        {
            // Instantiate the bullet at the position and rotation of the player
            GameObject clone;
            clone = Instantiate(weapon, transform.position, transform.rotation);


            // get the rigidbody component
            Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();


            // set the velocity
            rb.velocity = new Vector3(15 * moveDirection, 0, 0);


            // set the position close to the player
            rb.transform.position = new Vector3(transform.position.x, transform.position.y +
            2, transform.position.z + 1);
        }
    }

    void DoLand()
    {
        if( isJumping == true )
        {
            if( rb.velocity.y <= 0 )
            {
                // add a fall anim

                if (helper.ExtendedRayCollisionCheck(0, 0.1f) == true)
                {
                    isJumping = false;
                    anim.SetBool("Jump", false);
                }

            }
        }

    }


}
