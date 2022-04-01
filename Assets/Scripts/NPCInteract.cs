using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteract : MonoBehaviour
{
    public TMPro.TMP_Text interactText;
    public DialogueTrigger trigger;
    public Destination destination;
    public bool interactible = false;
    // Start is called before the first frame update
    void Start()
    {
        interactText.text = "";
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactible) {
            trigger.TriggerDialogue();
            interactText.text = "";
            destination.goToNext();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            interactText.text = "Press E to interact";
            interactible = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            interactText.text = "";
            interactible = false;
        }
    }
}
