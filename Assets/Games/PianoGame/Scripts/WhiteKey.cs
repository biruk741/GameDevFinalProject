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
            sprite.color = Color.blue;
        }
    }
}
