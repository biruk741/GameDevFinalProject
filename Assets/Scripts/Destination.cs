using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destination : MonoBehaviour
{
    public bool isDialogue = false;
    public GameObject npcInteract;
    public Transform nextLocation;
    // Start is called before the first frame update
    void Start()
    {
        if (isDialogue) {
            npcInteract.SetActive(true);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDialogue) npcInteract.SetActive(true);
        else if(npcInteract.active) npcInteract.SetActive(false);
    }
}
