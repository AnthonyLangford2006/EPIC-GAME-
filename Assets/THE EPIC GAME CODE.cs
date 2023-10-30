using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class THEEPICGAMECODE : MonoBehaviour
{
    SpriteRenderer sr;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        DoRun();

        void DoRun()
        {
            if (Input.GetKey("a") == true)
            {
                int speed = 4;
                print("Player pressed left");
                transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
                sr.flipX = true;
            }

            if (Input.GetKey("d") == true)
            {
                int speed = 4;

                print("Player pressed right");
                transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
                sr.flipX = false;
            }
        }


    }
}
