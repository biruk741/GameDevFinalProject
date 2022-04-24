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


    private int leftScore = 0;
    private int rightScore = 0;

    [Range(1, 100)]
    [SerializeField] private int maxScore;

    private WaitForSecondsRealtime endDelay = new WaitForSecondsRealtime(3);


    private void Awake()
    {
        maxScore -= 1;
        rightGoal.onScore += ()=> {
            if (leftScore >= maxScore || rightScore >= maxScore)
            {
                Restart(1);
            }
            else {
                leftScore++;
                leftScoreText.text = leftScore.ToString();
                ball.Restart();
            }

        };
        leftGoal.onScore += ()=> {
            if (leftScore >= maxScore || rightScore >= maxScore)
            {
                Restart(2);
            }
            else
            {
                rightScore++;
                rightScoreText.text = rightScore.ToString();
                ball.Restart();
            }
        };
        ball.Restart();
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
            Time.timeScale = 0;
            winText.text = $"Player {(leftScore > rightScore ? 1 : 2)} won!";
            yield return endDelay;
            Time.timeScale = 1;

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        StartCoroutine(win());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
