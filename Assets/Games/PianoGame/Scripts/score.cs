using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class score : MonoBehaviour
{
    public TextMeshProUGUI mytext;
    public int scorepoints = 0;
    
    public void Scoreupdate(int score)
    {
        scorepoints +=  score;
        mytext.text = "Score: " + scorepoints.ToString();
    }
}
