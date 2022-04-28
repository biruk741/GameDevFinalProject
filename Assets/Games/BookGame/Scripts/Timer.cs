using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Pause = !Pause;
    }

    [SerializeField] public TextMeshProUGUI uiText;
    public GameObject restartButton;
    public GameObject dialog;
    public int Duration;
    public AudioSource backgroundAudio;

    private int remainingDuration;

    private bool Pause;

    public static Timer Instance { get; private set; }
    private void Awake()
    {
        Instance = this;

    }

    private void Start()
    {
        StartCoroutine(BeginGame());
    }


    public void Being(int Second)
    {
        remainingDuration = Second;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (remainingDuration >= 0)
        {
            if (!Pause)
            {
                uiText.text = $"{remainingDuration / 60:00}:{remainingDuration % 60:00}";
                remainingDuration--;
                yield return new WaitForSeconds(1f);
            }
            yield return null;
        }
        OnEnd();
    }

    private void OnEnd()
    {
        PressButton.Instance.endGame = true;
        MeterBook.Instance.StopAllCoroutines();
        MeterBook.Instance.mask.fillAmount = 1;
       // PressButton.Instance.spriteRenderer.color = new Color(.1981132f, .1981132f, .1981132f, 1f);
        spawnbooks.Instance.bookindicators[PressButton.Instance.randomIndex].SetActive(false);
        backgroundAudio.Stop();
        GameObject.Find("DropBook").SetActive(false);
        if (PressButton.Instance.Score >= 10)
        {
            GameObject.Find("BodyText").GetComponent<TextMeshProUGUI>().text = "Wow You Actually Won";
            uiText.text = "";
            GameObject.Find("BookMessage").GetComponent<TextMeshProUGUI>().text = "";
            GameObject.Find("GameOutcome").GetComponent<TextMeshProUGUI>().text = "You Won";
            StartCoroutine(WaitForSceneLoad());
            
        } else if (PressButton.Instance.Score < 10)
        {
            GameObject.Find("BodyText").GetComponent<TextMeshProUGUI>().text = "Try Again";
            uiText.text = "";
            GameObject.Find("BookMessage").GetComponent<TextMeshProUGUI>().text = "";
            GameObject.Find("GameOutcome").GetComponent<TextMeshProUGUI>().text = "You Lose";
            restartButton.SetActive(true);
        } 
   
        print(PressButton.Instance.Score);

    }
    IEnumerator BeginGame()
    {
        var dialogtext = dialog.transform.Find("BodyText").GetComponent<TextMeshProUGUI>();
        dialogtext.text = "Game Has Started";
        backgroundAudio.Play();
        dialog.SetActive(true);
        yield return new WaitForSeconds(2);
        dialogtext.text = "Put 10 Books In Correct Spots To Win";
        yield return new WaitForSeconds(2);
        //GameObject.Find("StartGame").SetActive(false);
        PressButton.Instance.startGame = true;
        GameObject.Find("Score").GetComponent<TextMeshProUGUI>().text = "Score: 0";
        GameObject.Find("DropBook").GetComponent<TextMeshProUGUI>().text = "Can Drop Book: Yes";
        MeterBook.Instance.StartCoroutine(MeterBook.Instance.UpdatePowerBar());
        Being(Duration);
        PressButton.Instance.randomIndex = spawnbooks.Instance.GetRandomBook();
        spawnbooks.Instance.bookindicators[PressButton.Instance.randomIndex].SetActive(true);
        PressButton.Instance.bookMessage.text = "Match " + PressButton.Instance.bookText[PressButton.Instance.randomIndex].GetComponent<TextMeshProUGUI>().text + " Book";
        yield return null;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    private IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("LibraryArchivesScene");

    }
}
