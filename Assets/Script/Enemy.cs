using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Helper helper;

    public GameObject player;
    SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        helper = gameObject.AddComponent<Helper>();

    }


    void Update()
    {
        if (Input.GetKey("space"))
        {
            helper.FlipObject(true);    // this will execute the method in HelperScript.cs
        }

        Vector3 scale = transform.localScale;

        if (player.transform.position.x > transform.position.x)
        {
            sr.flipX = true;
            transform.position = new Vector2(transform.position.x + (0.2f * Time.deltaTime), transform.position.y);
            
        }

        if (player.transform.position.x < transform.position.x)
        {
            sr.flipX = false;
            transform.position = new Vector2(transform.position.x + (-0.2f * Time.deltaTime), transform.position.y);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);


        }
    }
}

