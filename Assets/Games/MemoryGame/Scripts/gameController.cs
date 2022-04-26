using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class gameController : MonoBehaviour
{
    public GameObject box;
    public TextMeshProUGUI clickCountTxt;
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
    public GameObject winnerPraised;
    public Button playAgain;
    float xPosition = -15f;
    float changeX = 10f;
    int cardsBy = 4;
    // public ElementVisible winnerPraise;
    int startCount;
    public GameObject dialog;
    List<GameObject> generatedObjects = new List<GameObject>();
    public int textShow = 1;
    public string[] text;
    private int clickCountTries;
    public AudioSource beforeGameStartsAudio;
    public AudioSource cardflipSound;
    private void Start()
    {
        var dialogtext = dialog.transform.Find("BodyText").GetComponent<TextMeshProUGUI>();
        dialogtext.text = "Game Has Started";
        beforeGameStartsAudio.Play();
        dialog.SetActive(true);
    }
    void OnEnable()
    {
        easyBtn.onClick.AddListener(() => EasySetup());
        mediumBtn.onClick.AddListener(() => MediumSetup());
        hardBtn.onClick.AddListener(() => HardSetup());
    }

    public void HardSetup()
    {
        HideButtons();
        GameObject.Find("Main Camera").transform.position = new Vector3(9.99f, -10.6f, -69.33f);
        GameObject.Find("chair").transform.position = new Vector3(10.52f, 0.9174957f, -9.97f);
        // yChange = -3f;
        //   yPosition = 9.5f;
        //  Scale = 12;
        numOfPictures = 24;
        cardsBy = 6;
        startCount = numOfPictures;
        GameObject.Find("NPC").transform.position = new Vector3(-10.21f, -23.69f, -4268f);
        var dialogtext = dialog.transform.Find("BodyText").GetComponent<TextMeshProUGUI>();
        dialogtext.text = "Win By Matching Cards With A Click Score <= " + 20.ToString();
        clickCountTries = 20;
        StartGame();
    }

    public void MediumSetup()
    {
        HideButtons();
        GameObject.Find("Main Camera").transform.position = new Vector3(-2.36f, -9.54f, -70.8f);
        GameObject.Find("chair").transform.position = new Vector3(-3.31f, 0.9174957f, -5.84f);
        xPosition = -25f;
        changeX = 15f;
        //   yPosition = 8f;
        // Scale = 8;
        // yChange = -4f;
        numOfPictures = 16;
        startCount = numOfPictures;
        GameObject.Find("NPC").transform.position = new Vector3(-23.4f, -21.8f, -4268.07f);
        var dialogtext = dialog.transform.Find("BodyText").GetComponent<TextMeshProUGUI>();
        dialogtext.text = "Win By Matching Cards With A Click Score <= " + 14.ToString();
        clickCountTries = 14;
        StartGame();
    }

    public void EasySetup()
    {
        GameObject.Find("Main Camera").transform.position = new Vector3(0f, 1.5f, -53.48f);
        HideButtons();
        GameObject.Find("NPC").transform.position = new Vector3(-19.9f, -10.46f, -4254.22f);
        //dialog.transform. = new Vector3(-170f, -127.2f, 0f);
        startCount = numOfPictures;
        var dialogtext = dialog.transform.Find("BodyText").GetComponent<TextMeshProUGUI>();
        dialogtext.text = "Win By Matching Cards With A Click Score <= " + 8.ToString();
        clickCountTries = 8;
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
        var sameX = xPosition;
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
            xPosition = xPosition + changeX;
            if (i % cardsBy < 1)
            {
                yPosition = yPosition + yChange;
                xPosition = sameX;
                row++;
            }
        }
    }

    public void cardDown(mainBox tempBox)
    {
        if (cardUp1 == tempBox)
        {
            cardUp1 = null;
            cardflipSound.Play();
        }
        else if (cardUp2 == tempBox)
        {
            cardUp2 = null;
            cardflipSound.Play();
        }
    }

    public bool cardUp(mainBox tempBox)
    {
        bool flipCard = true;
        if (cardUp1 == null)
        {
            cardUp1 = tempBox;
            cardflipSound.Play();
        }
        else if (cardUp2 == null)
        {
            cardUp2 = tempBox;
            cardflipSound.Play();
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
            clickCountTxt.text = "Click Score: " + clickCount.ToString();
            if (clickCount / textShow == 1)
            {
                textShow = textShow + 2;
                var dialogtext = dialog.transform.Find("BodyText").GetComponent<TextMeshProUGUI>();
                dialogtext.text = text[Random.Range(0, text.Length)];
               
            }
        }

        if (cardUp1 != null && cardUp2 != null &&
            cardUp1.index == cardUp2.index)
        {
            clickCount++;
            clickCountTxt.text = "Click Score: " + clickCount.ToString();
            cardUp1.matched = true;
            cardUp2.matched = true;
            cardUp1 = null;
            cardUp2 = null;
            index++;
            if (clickCount / textShow == 1)
            {
                textShow = textShow + 2;
                var dialogtext = dialog.transform.Find("BodyText").GetComponent<TextMeshProUGUI>();
                dialogtext.text = text[Random.Range(0, text.Length)];
               
            }
            if (index == startCount/2)
            {
                foreach (var obj in generatedObjects)
                {
                    Destroy(obj);
                }
                if (clickCount <= clickCountTries) {
                    var dialogtext = dialog.transform.Find("BodyText").GetComponent<TextMeshProUGUI>();
                    dialogtext.text = "Wow You Actually Won";
                    beforeGameStartsAudio.Stop();
                    StartCoroutine(WaitForSceneLoad());
                    winnerPraised.GetComponent<ElementVisible>().Visible = true;

                }


            }
        }
        if (clickCount > clickCountTries)
        {
        
            foreach (var obj in generatedObjects)
            {
                Destroy(obj);
            }
            var dialogtext = dialog.transform.Find("BodyText").GetComponent<TextMeshProUGUI>();
            dialogtext.text = "Try Again";
            beforeGameStartsAudio.Stop();
            winnerPraised.GetComponent<TextMeshProUGUI>().text = "You Lose";
            winnerPraised.GetComponent<ElementVisible>().Visible = true;
            playAgain.GetComponent<ElementVisible>().Visible = true;
        }
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("OutdoorsScene");

    }
}
