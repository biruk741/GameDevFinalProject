using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongPlayer : MonoBehaviour
{
    [SerializeField] private KeyCode upKey;
    [SerializeField] private KeyCode downKey;

    [SerializeField] private float speed;

    [SerializeField] private float minY;
    [SerializeField] private float maxY;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(upKey) && transform.position.y < maxY && PongManager.pongManager.GameEnd == false) {
            transform.position += new Vector3(0, Time.deltaTime * speed,0);
        }
        if (Input.GetKey(downKey) && transform.position.y > minY && PongManager.pongManager.GameEnd == false)
        {
            transform.position -= new Vector3(0, Time.deltaTime * speed, 0);
        }
    }
}
