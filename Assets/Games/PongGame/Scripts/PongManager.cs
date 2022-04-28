using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PongManager : MonoBehaviour
{
    [SerializeField] private Goal leftGoal;
    [SerializeField] private Goal rightGoal;
    [SerializeField] private Ball ball;

    [SerializeField] private TMP_Text leftScoreText;
    [SerializeField] private TMP_Text rightScoreText;

    [SerializeField] private TMP_Text winText;
    [SerializeField] public bool GameEnd = false;
    public string[] dialoguearray;
    public GameObject dialog;
    private int score;
    private int dialogcounter;
    private int leftScore = 0;
    private int rightScore = 0;

    [Range(1, 100)]
    [SerializeField] private int maxScore;

    private WaitForSecondsRealtime endDelay = new WaitForSecondsRealtime(3);
    public static PongManager pongManager { get; private set; }

    private void Awake()
    {
        pongManager = this;
        dialogcounter = 1;
        score = 0;
    }

    public void beginGame()
    {
        if (GameEnd == false)
        {
            maxScore -= 1;
            rightGoal.onScore += () =>
            {
                if (leftScore >= maxScore || rightScore >= maxScore)
                {
                    Restart(1);
                }
                else
                {
                    leftScore++;
                    leftScoreText.text = leftScore.ToString();
                    ball.Restart();
                    score++;
                }

            };
            leftGoal.onScore += () =>
            {
                if (leftScore >= maxScore || rightScore >= maxScore)
                {
                    Restart(2);
                }
                else
                {
                    rightScore++;
                    rightScoreText.text = rightScore.ToString();
                    ball.Restart();
                    score++;
                }
            };
            ball.Restart();
        }
    }

    private void Restart(int winner) {

        IEnumerator win() {
            if (winner == 1) {
                leftScore++;
                leftScoreText.text = leftScore.ToString();
            }
            else if (winner == 2)
            {
                rightScore++;
                rightScoreText.text = rightScore.ToString();
            }
            ball.endBallMovement();
            Time.timeScale = 0;
            winText.text = $" {(leftScore > rightScore ? "Player" : "Devin")} won";
            yield return endDelay;
            Time.timeScale = 1;
            if (leftScore > rightScore)
            {
                var dialogtext = GameObject.Find("BodyText").GetComponent<TextMeshProUGUI>();
                dialogtext.text = "Wow You Are Amazing";
                StartCoroutine(WaitForSceneLoad("IndyHall"));
            } else
            {
                var dialogtext = GameObject.Find("BodyText").GetComponent<TextMeshProUGUI>();
                dialogtext.text = "Try Again";
                StartCoroutine(WaitForSceneLoad(SceneManager.GetActiveScene().name));
            }
            GameEnd = true;
            yield return null;
        }
        StartCoroutine(win());
    }
    private IEnumerator WaitForSceneLoad(string n)
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(n);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (score / dialogcounter == 1)
        {
            var dialogtext = GameObject.Find("BodyText").GetComponent<TextMeshProUGUI>();
            dialogtext.text = dialoguearray[Random.Range(0, dialoguearray.Length)];
            dialogcounter = 3 + dialogcounter;
        }
    }
}
