using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Text clickCountTxt;
    public GameObject PlusOnePoint;
    public GameObject OnFire;
    public int numOfScorePerRound = 0;
    public static Score GetScore { get; private set; }


    private void Awake()
    {
        GetScore = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        numOfScorePerRound = numOfScorePerRound + 1;
        var number = int.Parse(clickCountTxt.text.ToString());
        number = number + 1;
        clickCountTxt.text = number.ToString();
        Shoot.ShootBall.numberOfBalls = Shoot.ShootBall.numberOfBalls - 1;
        PlusOnePoint.SetActive(true);
        Wait(0.5f, () =>
        {
            PlusOnePoint.SetActive(false);
        });
        OnFire.SetActive(true);
        basketball.GetBasketball.hitRim = true;
       
    }
    public void Wait(float seconds, System.Action callback)
    {
        StartCoroutine(WaitRoutine(seconds, callback));
    }
    IEnumerator WaitRoutine(float duration, System.Action callback)
    {
        yield return new WaitForSeconds(duration);
        callback?.Invoke();
    }

    

}
