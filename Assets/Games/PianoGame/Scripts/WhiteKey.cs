using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteKey : MonoBehaviour
{
    public SpriteRenderer sprite;
    private void OnMouseDown()
    {
        if (!Spawn.Instance.GameOver && Spawn.Instance.GameStarted)
        {
            StartCoroutine(Spawn.Instance.EndGame());
            sprite.color = new Color(0.1802243f, 0.1996276f, 0.2830189f);
        }
    }
}
