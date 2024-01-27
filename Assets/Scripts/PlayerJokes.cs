using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJokes : MonoBehaviour
{
    public Joke[] jokes;
    public const int jokes_limit = 3;

    void Awake()
    {
        jokes = new Joke[jokes_limit];
        for (int i = 0; i < jokes_limit; i++)
        {
            jokes[i] = ScriptableObject.CreateInstance<Joke>();
            jokes[i].setJoke("Test");
        }
    }
}
