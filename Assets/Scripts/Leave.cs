using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Leave : MonoBehaviour
{
    public TMPro.TMP_Text interactText;
    public Destination destination;
    public bool interactible = false;
    public string goToScene = "";
    public bool beginGame = false;
    // Start is called before the first frame update
    void Start()
    {
        interactText.text = "";
    }
    private void OnDisable()
    {
        interactText.text = "";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactible)
        {
            interactText.text = "";
            if (goToScene.Length > 0) SceneManager.LoadScene(goToScene);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
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
