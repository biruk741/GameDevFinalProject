using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] private float speed;
    [SerializeField] private Transform startPos;
    [SerializeField] private AudioSource bouncePlayer;
    [SerializeField] private AudioSource bounceEdge;
    [SerializeField] private AudioSource goalSound;
    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private bool gameEnd = false;
    [SerializeField] private bool startGame = false;
    public GameObject dialog;

    private WaitForSeconds beginDelay = new WaitForSeconds(1);


    public void Restart() {
        if (startGame == true)
        {
            StartCoroutine(moveBall());
        }
    }
    public void endBallMovement()
    {
        gameEnd = true;
    }
    public void ballV()
    {
        if (gameEnd == false) {
            float velocity = rigidBody.velocity.magnitude;
            int luminance = (int)(255 - velocity);
            luminance = (int)(luminance >= 0 ? luminance * 0.8 : 0);
            renderer.color = new Color(255, luminance, luminance); }
        else
        {
            rigidBody.velocity = new Vector3(0, 0, 0);
        }

    }

    IEnumerator moveBall() {
        transform.position = startPos.position;
        rigidBody.velocity = Vector3.zero;
        yield return beginDelay;
        float y;
        float x = Random.Range(2f, 5f);
        do
        {
            y = Random.Range(0.5f, 1f);
        } while (Mathf.Abs(y) < 0.4f);
        if (Random.Range(0f, 1f) > 0.5f)
        {
            y = -y;
        } else x = -x;
        Vector3 vector = new Vector3(x, y, 0);
        rigidBody.AddForce(vector.normalized * speed);
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            bouncePlayer.Play();
        }
        if (collision.gameObject.CompareTag("Goal"))
        {
            goalSound.Play();
        }
        if (collision.gameObject.CompareTag("Edge"))
        {
            bounceEdge.Play();
        }

        
    }
    IEnumerator StartGame()
    {
        var dialogtext = dialog.transform.Find("BodyText").GetComponent<TextMeshProUGUI>();
        dialogtext.text = "Game Has Started";
        dialog.SetActive(true);
        yield return new WaitForSeconds(1);
        dialogtext.text = "Beat Me At Pong To Win The Game";
        yield return new WaitForSeconds(2);
        startGame = true;
        yield return null;
        PongManager.pongManager.beginGame();
    }
    private void Start()
    {
        StartCoroutine(StartGame());

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (startGame == true)
        {
            ballV();
        }
}

}
