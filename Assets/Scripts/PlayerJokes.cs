using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJokes : MonoBehaviour
{
    public Joke[] jokes;
    public const int jokes_limit = 3;
    public int jokes_count = 0;

    private void Start()
    {
        jokes = new Joke[jokes_limit];
    }

    void Update()
    {
        jokes[jokes_count] = ScriptableObject.CreateInstance<Joke>();
        jokes[jokes_count].setJoke("Test");
        jokes_count++;
        gameObject.SetActive(false);
    }
}