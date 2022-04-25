using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Spawn : MonoBehaviour
{
    public float width = 7f;
    public float height = 20f;
    public GameObject note;
    GameObject tiles;
    private int prevRandomIndex;
    public int NotesToSpawn = 0;
    public AudioSource audioSource;
    public bool lastNote = false;
    private float songSegmentLength = 0.8f;
    private Coroutine playSongSegmentCoroutine;
    public static Spawn Instance { get; private set; }
    private int lastNoteId = 1;
    public int LastPlayedNoteId { get; set; } = 0;
    public float noteSpawnStartPosY;
    public bool PlayerWon = false;
    public bool GameOver;
    public Visibility startGame;
    public bool GameStarted;
    public AudioClip[] clipArray;
    public GameObject dialog;

    private void Awake()
    {
        Instance = this;
        GameOver = false;
        startGame.Visible = true;
        GameStarted = false;

    }
    // Start is called before the first frame update
    void Start()
    {
        var song = clipArray[Random.Range(0, clipArray.Length)];
        audioSource.clip = song;
        NotesToSpawn = Mathf.FloorToInt(audioSource.clip.length / songSegmentLength);
        SpawnNotes();
        noteSpawnStartPosY = height;
        StartCoroutine(StartGame()); 


    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
    }
    // Update is called once per frame
    void Update()
    {
     
    }


    public void SpawnNotes()
    {
        int notesToSpawn = NotesToSpawn;
        for (int i = 0; i < notesToSpawn; i++)
        {
            spawner();
            noteSpawnStartPosY = noteSpawnStartPosY + height;
            
        }
 
    }


    private int GetRandomIndex()
    {
        var randomIndex = Random.Range(0, 4);
        while (randomIndex == prevRandomIndex) randomIndex = Random.Range(0, 4);
        prevRandomIndex = randomIndex;
        return randomIndex;
    }

    void spawner()
    {
        var index = 0;
        var randomIndex = GetRandomIndex();
        foreach(Transform child in transform)
        {
            tiles = Instantiate(note, child.position, Quaternion.identity);
            tiles.transform.parent = child;
            tiles.transform.position = new Vector2(tiles.transform.position.x, noteSpawnStartPosY);
            tiles.GetComponent<noteaction>().Visible = (index == randomIndex);
            if (tiles.GetComponent<noteaction>().Visible)
            {
                tiles.GetComponent<noteaction>().Id = lastNoteId;
                lastNoteId++;
            }
            index++;
        }
    }
    public void PlaySomeOfSong()
    {
        if (!GameOver) {
            if (!audioSource.isPlaying && !lastNote)
            {
                audioSource.Play();
            }

            if (playSongSegmentCoroutine != null) StopCoroutine(playSongSegmentCoroutine);
            playSongSegmentCoroutine = StartCoroutine(PlaySomeOfSongCoroutine());
        } }

    private IEnumerator PlaySomeOfSongCoroutine()
    {
        if (!GameOver)
        {
            yield return new WaitForSeconds(songSegmentLength);
            audioSource.Pause();
        }
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    IEnumerator StartGame()
    {
        var dialogtext = dialog.transform.Find("BodyText").GetComponent<TextMeshProUGUI>();
        dialogtext.text = "Game Has Started";
        dialog.SetActive(true);
        yield return new WaitForSeconds(1);
        dialogtext.text = "Press All Black Keys With No Mistakes To Win";
        yield return new WaitForSeconds(2);
        startGame.Visible = false;
        GameStarted = true;
        yield return null;
    }

    public IEnumerator EndGame()
    {
        GameOver = true;
        yield return new WaitForSeconds(1);
        FindObjectOfType<GameOverScreen>().GameOver();

    }

}
