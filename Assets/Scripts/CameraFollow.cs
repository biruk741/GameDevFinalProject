using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private bool turnedRight = true;
    private bool turnedUp = true;
    [SerializeField] private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private Vector3 velocity = Vector3.zero;
    void FixedUpdate()
    {
        Vector3 currentPos = transform.position;
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, target.position, ref velocity, 0.15f);
        if (Input.GetKey(KeyCode.A) && turnedRight) {
            turnedRight = false;
        }
        if (Input.GetKey(KeyCode.D) && !turnedRight)
        {
            turnedRight = true;
        }
        if (Input.GetKey(KeyCode.S) && turnedUp) {
            turnedUp = false;
        }
        if (Input.GetKey(KeyCode.W) && !turnedUp)
        {
            turnedUp = true;
        }
        currentPos.x = !turnedRight ? smoothPosition.x-1 : smoothPosition.x +1;
        currentPos.y = !turnedUp ? smoothPosition.y-0.07f : smoothPosition.y +0.07f;
        transform.position = currentPos;
    }
}
