using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POI_Range : MonoBehaviour
{

    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {

        animator.SetBool("showing", false);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        print("Collided with " + other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("showing", true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        print("Collided with " + other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("showing", false);
        }
    }
}
