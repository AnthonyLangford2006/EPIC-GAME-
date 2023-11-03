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

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        helper = gameObject.AddComponent<Helper>();

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Jump", false);
        anim.SetBool("Run", false);
        int speed = 1;

        DoRun();

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
        int jumpAmount = 2;

        if (helper.ExtendedRayCollisionCheck(0, 0.1f) == true)
        {
            if (Input.GetKeyDown("w"))
            {

                rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
                anim.SetBool("Jump", true);
            }
        }
        


        if (Input.GetKeyDown("q"))
        {
            print("player pressed attack");
           
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
}
