using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [TextArea(1, 20)]
    public string[] sentences;


    public string character1Name;
    public string character2Name;

}
