using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Ball;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBasketball();
        }
    }

    void ShootBasketball()
    {
        GameObject BallIns = Instantiate(Ball, transform.position, transform.rotation);
        BallIns.GetComponent<Rigidbody2D>().velocity = transform.right * force;
    }
}
