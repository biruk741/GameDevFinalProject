using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
[ExecuteAlways]
public class ElementVisible : MonoBehaviour

{
    private CanvasGroup canvasGroup;
    public static ElementVisible Instance { get; private set; }
    [SerializeField]

    private bool visible;
    public bool Visible
    {
        get => visible;
        set
        {
            visible = value;
            if (visible) ShowElement();
            else HideElement();
        }
    }

    private void Awake()
    {
        Instance = this;

    }
    private void OnValidate()
    {
        if (Visible) ShowElement();
        else HideElement();
    }

    private void ShowElement()
    {
        if (!canvasGroup) canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    private void HideElement()
    {
        if (!canvasGroup) canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}