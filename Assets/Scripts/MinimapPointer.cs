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
        if (destinationProvided)
        {
            if (!gameObject.activeInHierarchy) gameObject.SetActive(true);
            Vector3 vector = (player.position - destination.position).normalized;
            float angleInRadians = Mathf.Atan2(vector.y, vector.x);
            double angleInDegrees = (180 / System.Math.PI) * angleInRadians;
            transform.localRotation = Quaternion.Euler(0, 0, (float)angleInDegrees + 90);
        }
        else gameObject.SetActive(false);
    }
}
