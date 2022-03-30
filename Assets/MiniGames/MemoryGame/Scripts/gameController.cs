using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{
    public GameObject box;
    public Text clickCountTxt;
    List<int> frontList = new List<int>{ 0, 1, 2, 3, 0, 1, 2, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10, 11, 11};
public static System.Random rnd = new System.Random();
    public int shuffleIndex = 0;
    int[] firstTwoCards = {-1,-2 };
    public bool checkCards;
    public Button easyBtn;
    public Button mediumBtn;
    public Button hardBtn;
    float yChange = -8f;
    float yPosition = 7.5f;
    int numOfPictures = 8;
    mainBox cardUp1 = null;
    mainBox cardUp2 = null;
    private int clickCount = 0;
    float Scale = 4;
    int index = 0;
    public Text winnerPraised;
    public Button playAgain;
    // public ElementVisible winnerPraise;
    int startCount;
    List<GameObject> generatedObjects = new List<GameObject>();

    void OnEnable()
    {
        easyBtn.onClick.AddListener(() => EasySetup());
        mediumBtn.onClick.AddListener(() => MediumSetup());
        hardBtn.onClick.AddListener(() => HardSetup());
    }

    public void HardSetup()
    {
        HideButtons();
        yChange = -3f;
        yPosition = 9.5f;
        Scale = 12;
        numOfPictures = 24;
        startCount = numOfPictures;
        StartGame();
    }

    public void MediumSetup()
    {
        HideButtons();
        yPosition = 8f;
        Scale = 8;
        yChange = -4f;
        numOfPictures = 16;
        startCount = numOfPictures;
        StartGame();
    }

    public void EasySetup()
    {
        HideButtons();
        startCount = numOfPictures;
        StartGame();
    }

    private void HideButtons()
    {
        easyBtn.gameObject.SetActive(false);
        mediumBtn.gameObject.SetActive(false);
        hardBtn.gameObject.SetActive(false);
    }


    void StartGame()
    {
        float xPosition = -15f;
        int row = 1;
        float ortho = Camera.main.orthographicSize / 2.0f;
        for (int i = 1; i < startCount + 1; i++)
        {
            shuffleIndex = rnd.Next(0, numOfPictures);
            var temp = Instantiate(box, new Vector3(xPosition, yPosition, -30.78f),Quaternion.identity);
            temp.GetComponent<mainBox>().index = frontList[shuffleIndex];
            temp.transform.localScale = new Vector3(ortho / Scale, ortho / Scale, 0);
            generatedObjects.Add(temp);
            frontList.Remove(frontList[shuffleIndex]);
            numOfPictures--;
            xPosition = xPosition + 10;
            if (i % 4 < 1)
            {
                yPosition = yPosition + yChange;
                xPosition = -15f;
                row++;
            }
        }
    }

    public void cardDown(mainBox tempBox)
    {
        if (cardUp1 == tempBox)
        {
            cardUp1 = null;
        }
        else if (cardUp2 == tempBox)
        {
            cardUp2 = null;
        }
    }

    public bool cardUp(mainBox tempBox)
    {
        bool flipCard = true;
        if (cardUp1 == null)
        {
            cardUp1 = tempBox;
        }
        else if (cardUp2 == null)
        {
            cardUp2 = tempBox;
        }
        else
        {
            flipCard = false;
        }
        return flipCard;
    }

    public void checkMatch()
    {
        if (cardUp1 != null && cardUp2 != null &&
               cardUp1.index != cardUp2.index)
        {
            clickCount++;
            clickCountTxt.text = clickCount.ToString();
        }

        if (cardUp1 != null && cardUp2 != null &&
            cardUp1.index == cardUp2.index)
        {
            clickCount++;
            clickCountTxt.text = clickCount.ToString();
            cardUp1.matched = true;
            cardUp2.matched = true;
            cardUp1 = null;
            cardUp2 = null;
            index++;
            print(index);
            print(startCount);
            if (index == startCount/2)
            {
                foreach (var obj in generatedObjects)
                {
                    Destroy(obj);
                }
                winnerPraised.GetComponent<ElementVisible>().Visible = true;
                playAgain.GetComponent<ElementVisible>().Visible = true;


            }
        }
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
