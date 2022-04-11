using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrintText : MonoBehaviour
{
    // Start is called before the first frame update
    public string textToBeTyped;
    public TMPro.TMP_Text textContainer;
    public bool printOnStart = true;
    public float speed = 10;

    private int curIndex = 0;
    private WaitForSeconds waitForSeconds;
    private WaitForSeconds waitForSecondsDelayed;
    public PrintText triggerNext;
    public bool isFinal = false;
    public string nextScene = "";
    private void Start()
    {
        waitForSeconds = new WaitForSeconds(1 / speed);
        waitForSecondsDelayed = new WaitForSeconds((1 / speed) * 10);
        if (printOnStart) printText();

        textContainer.text = "";
    }

    public void printText() {
        IEnumerator print()
        {
            while (curIndex < textToBeTyped.Length) {
                textContainer.text += textToBeTyped[curIndex];
                yield return textToBeTyped[curIndex] + "" != "." ? waitForSeconds: waitForSecondsDelayed;
                curIndex++;
            }
            if (triggerNext != null) { triggerNext.printText(); yield break; }
            if (isFinal) SceneManager.LoadScene(nextScene);
        }

        StartCoroutine(print());
    }


}
