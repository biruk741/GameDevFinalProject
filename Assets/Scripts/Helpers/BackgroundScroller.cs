using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public Transform startPos;
    public Transform endPos;

    private bool right = true;
    private WaitForSeconds wait;

    public float speed = 20;

    // Start is called before the first frame update
    void Start()
    {
        wait = new WaitForSeconds(1/speed);
        IEnumerator move() {
            while (true) {
                Vector3 pos = transform.position;
                pos.x += right ? 1 : -1;
                transform.position = pos;
                print("transform x = " + transform.position.x + " and startPos = " + startPos.position.x + " and endPos = " + endPos.position.x);
                if (transform.position.x < endPos.position.x || transform.position.x > startPos.position.x) right = !right;
                yield return wait;
            }
        }
        StartCoroutine(move());
    }
}
