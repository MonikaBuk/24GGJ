using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJokes : MonoBehaviour
{
    public Joke[] jokes;
    public JokeLoader loader;
    public const int jokes_limit = 3;
    public int jokes_count = 0;
    public int randnum;

    private void Start()
    {
        jokes = new Joke[jokes_limit];
        randomiser();
        
    }

    void Update()
    {   
        loader.jokelist(randnum);
        jokes[jokes_count] = ScriptableObject.CreateInstance<Joke>();
        jokes[jokes_count].setJoke(loader.test);
        print(jokes[jokes_count].content);
        jokes_count++;
        randomiser();
        gameObject.SetActive(false);
        
    }

    private void randomiser()
    {
        randnum = Random.Range(0, 2);
        print(randnum);
    }
}