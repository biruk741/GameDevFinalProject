using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button PlayButton;
    [SerializeField] private Button ContinueButton;
    [SerializeField] private Button ControlsOpenButton;
    [SerializeField] private Button ControlsClosedButton;
    [SerializeField] private GameObject ControlsUI;
    [SerializeField] private Button ExitButton;
    [SerializeField] private Button OptionsButton;
    [SerializeField] private Button SkipStoryButton;

    public GameObject playIndicator;
    public GameObject optionsIndicator;
    public GameObject exitIndicator;


    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        if(ControlsOpenButton != null)
        ControlsOpenButton.onClick.AddListener(() => { ControlsUI.SetActive(true); });
        if (ControlsClosedButton != null)
        ControlsClosedButton.onClick.AddListener(() => { ControlsUI.SetActive(false); });


        if (PlayButton != null)

            PlayButton.onClick.AddListener(() => { MissionTracker.ResetStats(); SceneManager.LoadScene("StoryTelling");  });
        if (ContinueButton != null)

            ContinueButton.onClick.AddListener(() => SceneManager.LoadScene("OutdoorsScene"));
        if (SkipStoryButton != null)
            WaitForSecondsRealtime(3);
            SkipStoryButton.onClick.AddListener(() => SceneManager.LoadScene("OutdoorsScene"));
    }

    private void WaitForSecondsRealtime(int v)
    {
        throw new NotImplementedException();
    }
}
