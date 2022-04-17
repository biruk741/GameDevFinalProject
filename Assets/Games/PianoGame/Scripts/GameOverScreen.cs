using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    //public Text endscore;
    private Visibility visibility;
    public Visibility winnerPraise;
    public GameObject dialogbox;
    // Start is called before the first frame update
    public void GameOver() 
            {
                visibility = GetComponent<Visibility>();
                visibility.Visible = true;
                
              //  endscore.text = FindObjectOfType<score>().scorepoints.ToString();
                 if (Spawn.Instance.PlayerWon){
                
                    winnerPraise.Visible = true;
                    dialogbox.SetActive(true);
                    var dialogtext = GameObject.Find("BodyText").GetComponent<TextMeshProUGUI>();
                    dialogtext.text = "WOW YOU ACTUALLY WON";
                }
        else
        {
            winnerPraise.GetComponent<Text>().text = "You  Lose";
            winnerPraise.Visible = true;
            dialogbox.SetActive(true);
            var dialogtext = GameObject.Find("BodyText").GetComponent<TextMeshProUGUI>();
            dialogtext.text = "I KNEW YOU WOULD LOSE";
        }
    }

    
}
