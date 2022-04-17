using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
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
    void Update()
    {
      
        if (Shoot.ShootBall.shoot == true && Shoot.ShootBall.gameStarted == true && Shoot.ShootBall.endGame == false)
        {
            moveBasketballUpAndDown();
            Shoot.ShootBall.shoot = false;
         //   moveNPC();
        }
    }


        

    private void moveBasketballUpAndDown()
    {
        y = maxY;
        x = Random.Range(minX, maxX);
        transform.position = new Vector3(x, y, 0);
    }
    private void moveNPC()
    {
        y = -2.89f;
        x = Random.Range(-44.69f, -4.66f);
        GameObject.Find("NPC").transform.position = new Vector3(x, y, 0);
    }


   

    }

   




