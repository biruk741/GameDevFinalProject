using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class Shoot : MonoBehaviour
{
    public GameObject Ball;
    public float force;
    public bool shoot;
    public int numberOfBalls = 0;
    public int limitOfBalls;
    public Image mask;
    private float currentbarValue;
    public static Shoot ShootBall { get; private set; }
    public GameObject restartGame;
    public GameObject gameStarted;
    public bool startGame;
    public bool endGame;
    public int numberOfBallsHitGround = 0;
    public int roundNumber = 1;
    public GameObject Rounds;
    public bool beginNewRound;
    public Queue<GameObject> ballQueue = new Queue<GameObject>();
    public TextMeshProUGUI periodTxt;
    public TextMeshProUGUI opponentScore;
    public GameObject outcome;
    public bool DisableMovement = false;
    public GameObject dialog;
    public AudioSource backgroundSound;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartGame());
    }

    private void Awake()
    {
        ShootBall = this;
        shoot = false;
        startGame = false;
        endGame = false;
        beginNewRound = false;
        opponentScore.text = Random.Range(3, 5).ToString();


    }
    // Update is called once per frame
    void Update()
    {
        currentbarValue = mask.fillAmount;
        if (Input.GetKeyDown(KeyCode.Space) && numberOfBalls < limitOfBalls && startGame == true && endGame == false)
        {
            ShootBasketball();
            shoot = true;
            numberOfBalls = numberOfBalls + 1;
        }
 
      

        if (beginNewRound == true && roundNumber < 4 && numberOfBallsHitGround - Score.GetScore.numOfScorePerRound == limitOfBalls)
        {
            beginNewRound = false;
            var increaseOpponentScore = int.Parse(opponentScore.text) + Random.Range(3, 5);
            opponentScore.text = increaseOpponentScore.ToString();
            roundNumber = roundNumber + 1;
            periodTxt.text = roundNumber.ToString();
            Rounds.GetComponentInChildren<TextMeshProUGUI>().text = "Round " + roundNumber.ToString();
            Rounds.SetActive(true);
            DisableMovement = true;
            backgroundSound.Stop();
            Score.GetScore.Wait(3, () =>
            {
               
                Rounds.SetActive(false);
                numberOfBalls = 0;
                Score.GetScore.counter = 1;
                numberOfBallsHitGround = 0;
                Score.GetScore.numOfScorePerRound = 0;
                Score.GetScore.counter = 1;
                DisableMovement = false;
                backgroundSound.Play();

            });
        }
        if (ballQueue.Count > 0 && numberOfBallsHitGround - Score.GetScore.numOfScorePerRound == limitOfBalls)
            Destroy(ballQueue.Dequeue());
        else if(ballQueue.Count > 0 && ballQueue.Count >= 10)
        {
            Destroy(ballQueue.Dequeue());
        }

    }

  

    void ShootBasketball()
    {
        GameObject BallIns = Instantiate(Ball, transform.position, transform.rotation);
        BallIns.GetComponent<Rigidbody2D>().velocity = transform.right * force * (1-currentbarValue);
        ballQueue.Enqueue(BallIns);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator StartGame()
    {
        var dialogtext = dialog.transform.Find("BodyText").GetComponent<TextMeshProUGUI>();
        dialogtext.text = "Game Has Started";
        dialog.SetActive(true);
        yield return new WaitForSeconds(2);
        dialogtext.text = "Score More Than Me To Win";
        yield return new WaitForSeconds(2);
        startGame = true;
        backgroundSound.Play();
        gameStarted.SetActive(false);
        yield return null;
    }




    public void EndGame()
    {
        endGame = true;
        
        if (int.Parse(Score.GetScore.clickCountTxt.text) < int.Parse(opponentScore.text))
        {
            outcome.SetActive(true);
            outcome.GetComponentInChildren<TextMeshProUGUI>().text = "You Lose";
            dialog.SetActive(true);
            GameObject.Find("BodyText").GetComponent<TextMeshProUGUI>().text = "Try Again";
            restartGame.SetActive(true);
        } else if (int.Parse(Score.GetScore.clickCountTxt.text) > int.Parse(opponentScore.text))
        {
            outcome.SetActive(true);
            outcome.GetComponentInChildren<TextMeshProUGUI>().text = "You Win";
            dialog.SetActive(true);
            GameObject.Find("BodyText").GetComponent<TextMeshProUGUI>().text = "You Win";
            StartCoroutine(WaitForSceneLoad());

        } else if (int.Parse(Score.GetScore.clickCountTxt.text) == int.Parse(opponentScore.text))
        {
            outcome.SetActive(true);
            outcome.GetComponentInChildren<TextMeshProUGUI>().text = "Tie Game";
            dialog.SetActive(true);
            GameObject.Find("BodyText").GetComponent<TextMeshProUGUI>().text = "We Tied So Try Again";
            restartGame.SetActive(true);
        }
        backgroundSound.Stop();
     

    }

    private IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("CSCGym");

    }


}
