using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private float maxY = 10.22f;
    private float minY = -10.22f;
    public int speed;
    private bool direction = true;
    // Start is called before the first frame update 
    void Start()
    {
        moveBasketball();
    }


    // Update is called once per frame 
    void Update()
    {
        moveBasketball();
    }

    public void moveBasketball()
    {
        if (direction)
            transform.Translate(Vector2.up * speed * Time.deltaTime, Space.World);
        else
            transform.Translate(-Vector2.up * speed * Time.deltaTime, Space.World);
        if (transform.position.y >= maxY)
        {
            direction = false;
        }

        if (transform.position.y <= minY)
        {
            direction = true;
        }

    }
}