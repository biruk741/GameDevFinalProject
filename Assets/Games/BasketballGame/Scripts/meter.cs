using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class meter : MonoBehaviour
{
    public Image mask;
    public float barChangeSpeed = 1;
    float maxbarValue = 100;
    float currenbarValue;
    bool powerIncrease;
    bool powerOn;
    private int numberOfTimesCalled = 1;

    // Start is called before the first frame update 
    void FixedUpdate()
    {
        if (Shoot.ShootBall.startGame == true && numberOfTimesCalled == 1  && Shoot.ShootBall.endGame == false)
        {
            currenbarValue = 1;
            powerIncrease = true;
            powerOn = true;
            StartCoroutine(UpdatePowerBar());
            numberOfTimesCalled = 2;
        }

        if(Shoot.ShootBall.endGame == true && numberOfTimesCalled == 2)
        {
          
            StopAllCoroutines();
            mask.fillAmount = 1;
        }
    }

    IEnumerator UpdatePowerBar()
    {
        while (powerOn)
        {
            if (!powerIncrease && Shoot.ShootBall.DisableMovement == false)
            {
                currenbarValue -= barChangeSpeed;
                if (currenbarValue <= 0)
                {
                    powerIncrease = true;
                }
            }
            if (powerIncrease && Shoot.ShootBall.DisableMovement == false)
            {
                currenbarValue += barChangeSpeed;
                if (currenbarValue >= maxbarValue)
                {
                    powerIncrease = false;
                }
            }

            float fill = currenbarValue / maxbarValue;
            mask.fillAmount = fill;
            yield return new WaitForSeconds(0.02f);


        }
        yield return null;
    }


    // Update is called once per frame 
    void Update()
    {

    }
}
