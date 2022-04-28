using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public AudioSource talkingSound;

    public TMPro.TMP_Text NPCNameField;
    public TMPro.TMP_Text NPCDialogField;

    public GameObject wholeDialogue;

    public string[] sentences;
    public string NPCName;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            wholeDialogue.SetActive(true);
            NPCNameField.text = NPCName;
            if(sentences.Length > 0)
            NPCDialogField.text = sentences[Random.Range(0, sentences.Length)];
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            wholeDialogue.SetActive(false);

        }
    }

}
