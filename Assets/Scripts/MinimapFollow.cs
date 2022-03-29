using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private Vector3 velocity = Vector3.zero;
    void FixedUpdate()
    {
        Vector3 currentPos = target.position;
        currentPos.x = currentPos.x + 10000;
        transform.position = currentPos;
    }
}
