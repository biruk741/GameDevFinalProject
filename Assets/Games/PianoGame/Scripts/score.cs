using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class score : MonoBehaviour
{
    public TextMeshProUGUI mytext;
    public int scorepoints = 0;
    public GameObject dialog;
    public string[] text;
    private int counter = 10;
    public void Scoreupdate(int score)
    {
        scorepoints +=  score;
        mytext.text = "Score: " + scorepoints.ToString();
        if(scorepoints/counter == 1)
        {
            var dialogtext = dialog.transform.Find("BodyText").GetComponent<TextMeshProUGUI>();
            dialogtext.text = text[Random.Range(0, text.Length)];
            dialog.SetActive(true);
            counter = 10 + counter;
        }

    }
}
