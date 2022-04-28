using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPlayer : MonoBehaviour
{

    [SerializeField] private float speed;

    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    [SerializeField] private GameObject Ball;
    // Start is called before the first frame update
    void Start()
    {

    }


    void Update()

    {
        if (PongManager.pongManager.GameEnd == false)
        {
            if (Ball.transform.position.y < transform.position.y || Ball.transform.position.y > transform.position.y
                && transform.position.y < maxY && transform.position.y > minY)
            {
                var position = new Vector3(120f, Ball.transform.position.y, 0);
                transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime * speed);
            }
            else
            {

                var position = new Vector3(120f, Ball.transform.position.y, 0);
                transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime * speed);
            }
        }
    }

}

