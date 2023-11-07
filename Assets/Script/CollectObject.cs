using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObject : MonoBehaviour
{
    private Object thisObject;
    public GameObject gm;
    private Collectable collectable;
    private void Awake()
    {
        collectable = gm.GetComponent<Collectable>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collectable.score += 1f;
            Destroy(gameObject);
        } 
    }
}
