using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PressButton : MonoBehaviour
{
   // public SpriteRenderer spriteRenderer;
    public bool startGame;
    public bool endGame;
    private float[] fiveValues = new float[] { 0.2f, 0.4f, 0.6f, .8f, 1f };
    public Image mask;
    private float fillAmount;
    private Color color;
    private bool _inputLocked;
    public float inputlockingTime;
    public bool timerIsRunning = false;
    public bool startLock = true;
    public int randomIndex;
    [SerializeField] public TextMeshProUGUI bookMessage;
    public GameObject[] bookText;
    public int Score;
    public int countertext = 1;
    public static PressButton Instance { get; private set; }
   
    private void Awake()
    {
        Instance = this;
    //    spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        color = new Color(1, 1, 1, 1);
        _inputLocked = false;
        startGame = false;
        endGame = false;
        Score = 0;
    }

    private void Start()
    {
 
    }


    void Update()
    {
        if (_inputLocked == false && startGame == true && endGame != true)
        {
            if (Input.GetMouseButtonDown(0))
            {

                {
                    var closestDistance = 2f;
                    var index = 0;
                    fillAmount = 1 - mask.fillAmount;
                    foreach (float i in fiveValues)
                    {
                        if (Mathf.Abs(fillAmount - i) <= closestDistance)
                        {
                            closestDistance = Mathf.Abs(fillAmount - i);
                            index++;
                        }

                    }

                    GameObject.Find("DropBook").GetComponent<TextMeshProUGUI>().text = "Can Drop Book: No";
                    spawnbooks.Instance.callBook(index, randomIndex);
                    spawnbooks.Instance.bookindicators[randomIndex].SetActive(false);
                    LockInput();
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (timerIsRunning && endGame != true)
        {
            if (inputlockingTime > 0f)
            {
                inputlockingTime -= Time.deltaTime;
            }
            else
            {
                inputlockingTime = 0;
                randomIndex = spawnbooks.Instance.GetRandomBook();
                bookMessage.text = "Match " + bookText[randomIndex].GetComponent<TextMeshProUGUI>().text + " Book";
                spawnbooks.Instance.bookindicators[randomIndex].SetActive(true);
                GameObject.Find("DropBook").GetComponent<TextMeshProUGUI>().text = "Can Drop Book: Yes";
                _inputLocked = false;
                timerIsRunning = false;
            }
        }
    
}
    void LockInput()
    {
        _inputLocked = true;
        timerIsRunning = true;
        inputlockingTime = 3f;
}

    


}
