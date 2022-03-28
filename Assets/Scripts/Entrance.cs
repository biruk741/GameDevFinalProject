using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    float counter = 0;
    int direction = 1;
    public BoxCollider2D playerCollider;
    public TMPro.TMP_Text UIText;
    bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        IEnumerator anim() {
            while (true) {
               transform.position = new Vector3(transform.position.x, transform.position.y + direction);
               counter += direction;
               if (counter >= 10) direction = -1;
               else if (counter <= 0) direction = 1;
               yield return new WaitForSeconds(0.1f);
            }
        }
        StartCoroutine(anim());
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E) && isActive) {
            print("Entering Building");
            LoadingScreen.LoadScene("MainMenuScene");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.CompareTag("Player") + "arrow enter");
        if (collision.gameObject.CompareTag("Player")) {

            UIText.text = "Press [E] to enter";
            isActive = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        print(collision.gameObject.CompareTag("Player") + "arrow exit");

        if (collision.gameObject.CompareTag("Player"))
        {
            UIText.text = "";
            isActive = false;
        }
    }
}
