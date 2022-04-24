using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteKey : MonoBehaviour
{
    public SpriteRenderer sprite;
    public AudioSource whiteSound;
    public AudioClip[] clipArray;
    private void OnMouseDown()
    {
        if (!Spawn.Instance.GameOver && Spawn.Instance.GameStarted)
        {
            var song = clipArray[Random.Range(0, clipArray.Length)];
            whiteSound.clip = song;
            StartCoroutine(Spawn.Instance.EndGame());
            sprite.color = new Color(0.1802243f, 0.1996276f, 0.2830189f);
            whiteSound.Play();
        }
    }
}
