using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TriggerArea : MonoBehaviour
{
    public string tag;
    public GameObject bookMessage;
    public GameObject Score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag ==  tag)
        {
            bookMessage.SetActive(true);
            PressButton.Instance.Score = PressButton.Instance.Score + 1;
            Score.GetComponent<TextMeshProUGUI>().text = "Score: " + PressButton.Instance.Score.ToString();
            Wait(2f, () =>
            {
                bookMessage.SetActive(false);
            });
        }
    }
    public void Wait(float seconds, System.Action callback)
    {
        StartCoroutine(WaitRoutine(seconds, callback));
    }
    IEnumerator WaitRoutine(float duration, System.Action callback)
    {
        yield return new WaitForSeconds(duration);
        callback?.Invoke();
    }

}
