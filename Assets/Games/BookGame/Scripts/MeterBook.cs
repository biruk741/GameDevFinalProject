using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeterBook : MonoBehaviour
{
    public Image mask;
    public float barChangeSpeed = 1;
    float maxbarValue = 100;
    float currenbarValue;
    bool powerIncrease;
    bool powerOn;
    int expectedIncrease;
    public static MeterBook Instance { get; private set; }
    private void Awake()
    {
        Instance = this;

    }

    // Start is called before the first frame update 
    void Start()
    {

        currenbarValue = 1;
        powerIncrease = true;
        powerOn = true;
        expectedIncrease = 2;

    }

    public IEnumerator UpdatePowerBar()
    {
        while (powerOn)
        {
            increaseSpeed();
            if (!powerIncrease)
            {
                currenbarValue -= barChangeSpeed;
                if (currenbarValue <= 0)
                {
                    powerIncrease = true;
                }
            }
            if (powerIncrease)
            {
                currenbarValue += barChangeSpeed;
                if (currenbarValue >= maxbarValue)
                {
                    powerIncrease = false;
                }
            }

            float fill = currenbarValue / maxbarValue;
            mask.fillAmount = 1-fill;
            yield return new WaitForSeconds(0.02f);


        }
        yield return null;
    }


    void increaseSpeed()
    {
        var score = PressButton.Instance.Score;
        if(score >= expectedIncrease)
        {
            expectedIncrease = expectedIncrease + 2;
            barChangeSpeed = barChangeSpeed * 1.25f;
        }

    }

    // Update is called once per frame 
    void Update()
    {

    }
}