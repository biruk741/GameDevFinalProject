using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button PlayButton;
    [SerializeField] private Button ControlsOpenButton;
    [SerializeField] private Button ControlsClosedButton;
    [SerializeField] private GameObject ControlsUI;
    [SerializeField] private Button ExitButton;


    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        ControlsOpenButton.onClick.AddListener(() => { ControlsUI.SetActive(true); });
        ControlsClosedButton.onClick.AddListener(() => { ControlsUI.SetActive(false); });
        PlayButton.onClick.AddListener(() => SceneManager.LoadScene("OutdoorsScene"));
    }
}
