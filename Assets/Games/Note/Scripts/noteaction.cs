using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteaction : MonoBehaviour
{
    public Animator animator;
    public int scorepoints = 1;
    public int index;
    public float noteSpeed;

    public int Id { get; set; }
    public bool Played { get; set; }
    private bool visible;
    public bool Visible
    {
        get => visible;
        set
        {
            visible = value;
            if (!visible) animator.Play("Invisible");
        }
    }

    public void Awake()
    {
       
        animator = GetComponent<Animator>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (!Spawn.Instance.GameOver && Spawn.Instance.GameStarted) {
            transform.Translate(Vector2.down * noteSpeed * Time.deltaTime);
        }
        
    } 

    private void OnMouseDown()
    {
        if (!Spawn.Instance.GameOver && Spawn.Instance.GameStarted)
        {
            if (Visible)
            {
                if (!Played && Spawn.Instance.LastPlayedNoteId == Id - 1)
                {
                    Played = true;
                    Spawn.Instance.LastPlayedNoteId = Id;
                    FindObjectOfType<score>().Scoreupdate(scorepoints);
                    Spawn.Instance.PlaySomeOfSong();
                    animator.Play("Played");
                    print(Id);
                    print(Spawn.Instance.NotesToSpawn);
                    if(Id == Spawn.Instance.NotesToSpawn)
                    {
                        Spawn.Instance.lastNote = true;
                        Spawn.Instance.PlayerWon = true;
                        StartCoroutine(Spawn.Instance.EndGame());
                    }
                }
            }
            else
            {
                StartCoroutine(Spawn.Instance.EndGame());
                animator.Play("Missed");
            }
        }

    }

    public void OutOfScreen()
    {
        if (!Spawn.Instance.GameOver && !Played && Spawn.Instance.GameStarted) {
            if (Visible)
            {
                StartCoroutine(Spawn.Instance.EndGame());
                animator.Play("Missed");
            }
        }
    }




}
