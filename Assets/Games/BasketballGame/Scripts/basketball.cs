using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class basketball : MonoBehaviour
{
    Rigidbody2D rb;
    bool hasCollided = false;
    public bool hitRim;

    public static basketball GetBasketball { get; private set; }


    private void Awake()
    {
        GetBasketball = this;
        hitRim = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
            trackMovement();
    }

    void trackMovement()
    {
        Vector2 direction = rb.velocity;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground" && hasCollided == false)
        {
            hasCollided = true;
            Shoot.ShootBall.numberOfBallsHitGround = Shoot.ShootBall.numberOfBallsHitGround + 1;
            if (Shoot.ShootBall.numberOfBallsHitGround / Score.GetScore.counter == 1)
            {
                Score.GetScore.counter += 4;
                var dialogtext = Score.GetScore.dialog.transform.Find("BodyText").GetComponent<TextMeshProUGUI>();
                dialogtext.text = Score.GetScore.text[Random.Range(0, Score.GetScore.text.Length)];
                Score.GetScore.dialog.SetActive(true);
                
            }
            if (hitRim == false)
            {
                Score.GetScore.OnFire.SetActive(false);
            }
            if (Shoot.ShootBall.numberOfBallsHitGround - Score.GetScore.numOfScorePerRound == Shoot.ShootBall.limitOfBalls)
            {
                
                Shoot.ShootBall.beginNewRound = true;
                if (Shoot.ShootBall.roundNumber == 4)
                {
                    
                    Shoot.ShootBall.EndGame();
                }
            }
        }
    }





}
