using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POI : MonoBehaviour
{
    public TMPro.TMP_Text poi_name_display;
    public TMPro.TMP_Text description_display;

    public string poiName;
    public string poiDescription;

    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        poi_name_display.text = poiName;
        description_display.text = poiDescription;

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
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Collided with " + other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("showing", true);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        print("Collided with " + other.collider.gameObject.name);
        if (other.collider.gameObject.CompareTag("Player"))
        {
            animator.SetBool("showing", true);
        }
    }
    private void OnCollisionEnter2D(Collider2D other)
    {
        print("Collided with " + other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("showing", true);
        }
    }
}
