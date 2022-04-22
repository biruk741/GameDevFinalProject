using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnbooks : MonoBehaviour
{
    public GameObject[] spawnBooks;
    public string[] tags;
    public GameObject[] prefabBooks;
    private int[] prefabArrayCalled = new int[] { 0, 0, 0, 0, 0 };
    public GameObject[] bookindicators;
    public int bookDropCounter;
    public static spawnbooks Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
        bookDropCounter = 0;

    }
    // Start is called before the first frame update
    private void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void callBook(int i, int randomIndex)
    {
        SpawnBooks(i-1, randomIndex);
        StartCoroutine(waitTime());
        
    }
    IEnumerator waitTime()
    {
        yield return new WaitForSeconds(2);
    }
    public void SpawnBooks(int i, int spawnRandomBook)
    {
        if (PressButton.Instance.endGame != true)
        {
            GameObject book = spawnBooks[spawnRandomBook];
            bookindicators[spawnRandomBook].SetActive(true);

            var bookprefab = Instantiate(book, GameObject.FindGameObjectWithTag(tags[i]).transform.position, Quaternion.identity);
            if (prefabArrayCalled[i] == 0)
            {
                bookprefab.transform.SetParent(GameObject.FindGameObjectWithTag(tags[i]).transform);
                prefabBooks[i] = bookprefab;
                prefabArrayCalled[i] = prefabArrayCalled[i] + 1;
            }
            else
            {

                bookprefab.transform.SetParent(prefabBooks[i].transform);
                prefabBooks[i] = bookprefab;
                prefabArrayCalled[i] = prefabArrayCalled[i] + 1;
            }

        }
    }
    public int GetRandomBook()
    {

        var randomIndex = Random.Range(0, 5);
        return randomIndex;
    }

  
}
