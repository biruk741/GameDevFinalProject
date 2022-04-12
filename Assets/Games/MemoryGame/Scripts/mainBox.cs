using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainBox : MonoBehaviour
{
    GameObject gameControl;
    SpriteRenderer spriteRenderer;
    public Sprite[] front;
    public Sprite back;
    public int index;
    public bool matched = false;


    private void Awake()
    {
        gameControl = GameObject.Find("gameController");
        spriteRenderer = GetComponent<SpriteRenderer>();
        System.Random _random = new System.Random();
        Sprite randomIndex;
        int n = front.Length;
        for (int i = 0; i < n; i++)
        {
            int r = i + (int)(_random.NextDouble() * (n - i));
            randomIndex = front[r];
            front[r] = front[i];
            front[i] = randomIndex;
        }
    }

    public void OnMouseDown()
    {
        if (matched == false)
        {
            gameController controlScript = gameControl.GetComponent<gameController>();
            if (spriteRenderer.sprite == back)
            {
                if (controlScript.cardUp(this))
                {
                    spriteRenderer.sprite = front[index];
                    controlScript.checkMatch();
                }
            }
            else
            {
                spriteRenderer.sprite = back;
                controlScript.cardDown(this);
            }
        }
    }    
}
