using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject indicator;
    public TMPro.TMP_Text text;
    public bool hasDelay = false;

    public bool isContinue;

    private void Start()
    {
        IEnumerator start() {
            if (hasDelay) yield return new WaitForSeconds(2);
            gameObject.SetActive(MissionTracker.instance.level != 0);
        }
        if (isContinue)
        {
            StartCoroutine(start());
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        indicator.SetActive(true);
        text.fontSize += 3;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        indicator.SetActive(false);
        text.fontSize -= 3;
    }


}
