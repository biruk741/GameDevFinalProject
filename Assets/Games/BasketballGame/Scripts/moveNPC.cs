using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveNPC : MonoBehaviour
{
    private float x;
    private float y;
    public float maxY;
    public float maxX;
    public float minX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if ( Shoot.ShootBall.gameStarted == true && Shoot.ShootBall.endGame == false)
        {
            moveBasketballUpAndDown();
            Shoot.ShootBall.shoot = false;
        }

    }
    private void moveBasketballUpAndDown()
    {
        y = maxY;
        x = Random.Range(minX, maxX);
        transform.position = new Vector3(x, y, 0);
    }
}
