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

    public int Duration;

    private int remainingDuration;

    private bool Pause;

    public static Timer Instance { get; private set; }
    private void Awake()
    {
        Instance = this;

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
        GameObject.Find("DropBook").SetActive(false);
        restartButton.SetActive(true);
        print(PressButton.Instance.Score);

    }
    public void BeginGame()
    {
        GameObject.Find("StartGame").SetActive(false);
        PressButton.Instance.startGame = true;
        GameObject.Find("Score").GetComponent<TextMeshProUGUI>().text = "Score: 0";
        GameObject.Find("DropBook").GetComponent<TextMeshProUGUI>().text = "Can Drop Book: Yes";
        MeterBook.Instance.StartCoroutine(MeterBook.Instance.UpdatePowerBar());
        Being(Duration);
        PressButton.Instance.randomIndex = spawnbooks.Instance.GetRandomBook();
        spawnbooks.Instance.bookindicators[PressButton.Instance.randomIndex].SetActive(true);
        PressButton.Instance.bookMessage.text = "Match " + PressButton.Instance.bookText[PressButton.Instance.randomIndex].GetComponent<TextMeshProUGUI>().text + " Book";
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
