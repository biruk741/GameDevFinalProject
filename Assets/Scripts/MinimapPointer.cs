using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapPointer : MonoBehaviour
{
    public Transform player;
    private Transform currentDestination;

    public void SetDestination(Transform dest)
    {
        currentDestination = dest;
        //do other setup stuff
    }

    public static MinimapPointer instance;

    bool destinationProvided = false;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        destinationProvided = currentDestination != null;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        destinationProvided = currentDestination != null;
        if (destinationProvided)
        {
            if (!gameObject.activeInHierarchy) gameObject.SetActive(true);
            Vector3 vector = (player.position - currentDestination.position).normalized;
            float angleInRadians = Mathf.Atan2(vector.y, vector.x);
            double angleInDegrees = (180 / System.Math.PI) * angleInRadians;
            transform.localRotation = Quaternion.Euler(0, 0, (float)angleInDegrees + 90);
        }
        else gameObject.SetActive(false);
    }
}
