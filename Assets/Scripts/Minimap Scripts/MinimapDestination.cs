using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapDestination : MonoBehaviour
{

    private Vector3 destinationPos;

    // Update is called once per frame
    void Update()
    {
        Destination obj = FindObjectOfType<Destination>();
        if (obj != null && obj.gameObject != null)
        {
            destinationPos = obj.gameObject.transform.position;
            destinationPos.x += 10_000;
            transform.position = destinationPos;
        }
        


    }
}
