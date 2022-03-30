using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    private Text clickCountTxt;
    // Start is called before the first frame update
    void Start()
    {
        clickCountTxt = GameObject.Find("ScoreOne").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        var number = int.Parse(clickCountTxt.text.ToString());
        number = number + 1;
        print(number);
        clickCountTxt.text = number.ToString();
        
    }

}
