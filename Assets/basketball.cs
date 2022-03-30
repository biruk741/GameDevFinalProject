using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basketball : MonoBehaviour
{
    Rigidbody2D rb;
    bool hasHit = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasHit == false)
        {
            trackMovement();
        }
    }

    void trackMovement()
    {
        Vector2 direction = rb.velocity;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //  rb.isKinematic = true;
        hasHit = true;
        // rb.velocity = Vector2.zero;
      

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "FrontNet")
        {
            
            Physics2D.IgnoreCollision(GameObject.Find("insidenetone").GetComponent<Collider2D>(),GetComponent<Collider2D>());
            Physics2D.IgnoreCollision(GameObject.Find("rimbar").GetComponent<Collider2D>(), GetComponent<Collider2D>());
            print(1);
        }

    }

 

}
