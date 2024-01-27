using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Joke", menuName = "ScriptableObjects/Joke", order = 1)]
public class Joke : ScriptableObject
{
    public string content;

    public void setJoke(string s)
    {
        content = s;
    }
}
