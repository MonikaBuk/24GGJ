using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJokes : MonoBehaviour
{
    public Joke[] jokes;
    public JokeLoader loader;
    public const int jokes_limit = 3;
    public static int jokes_count;
    public int randnum;

    private void Start()
    {
        jokes = new Joke[jokes_limit];
        randomiser();
        
    }

    void Update()
    {   
        
    }

    private void randomiser()
    {
        randnum = Random.Range(0, 4);
        loader.jokelist(randnum);
        print(randnum);
        
    }

    public void addjoke()
    {
        jokes[jokes_count] = ScriptableObject.CreateInstance<Joke>();
        jokes[jokes_count].setJoke(loader.test);
        jokes_count++;
        print(jokes[jokes_count - 1].content);
        randomiser();
    }

    public void removelast()
    {
        jokes[jokes_count -1] = null;
        jokes_count--;
    }
}