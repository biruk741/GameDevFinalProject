using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapPointer : MonoBehaviour
{
    public Transform player;
    public Transform destination;

    bool destinationProvided = false;
    // Start is called before the first frame update
    void Start()
    {
        destinationProvided = destination != null;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        destinationProvided = destination != null;
        if (destinationProvided) {
            Vector3 vector = (player.position - destination.position).normalized;
            float angleInRadians = Mathf.Atan(vector.y/vector.x);
            double angleInDegrees = (180 / System.Math.PI) * angleInRadians;
            Quaternion rotation = transform.rotation;

            print("vector.x = " + vector.x + " and vector.y = " + vector.y + " y/x = " + (vector.x/vector.y));

            //rotation.z = 1-Mathf.Atan(vector.y / vector.x) *Mathf.Rad2Deg / 90f;
            // rotation.z = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
            rotation.z = vector.x;
            rotation.w = -vector.y;
                        //rotation.w = vector.y < 0 ? -vector.y: vector.y;
            transform.rotation = rotation;
        }
    }
}
