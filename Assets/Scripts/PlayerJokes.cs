using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJokes : MonoBehaviour
{
    //public static PlayerJokes instance;
    public static Joke[] jokes = new Joke[3];
    public JokeLoader loader;
    public const int jokes_limit = 3;
    public static int jokes_count;
    public int randnum;

    [SerializeField] GameObject joke1;
    [SerializeField] GameObject joke2;
    [SerializeField] GameObject joke3;

    private void Start()
    {
        //jokes = new Joke[jokes_limit];
        randnum = Random.Range(0, 8);
        loader.jokelist(randnum);

    }

    void Update()
    {   
        if(jokes_count > 0) 
        { 
            for(int i = 0; i <= jokes_count-1; i++) 
            {
                Debug.Log(jokes[i].content);
            }
        }
        if (jokes_count == 1)
        {
            joke1.SetActive(true);
            joke2.SetActive(false);
            joke3.SetActive(false);
        }
        else if (jokes_count == 2)
        {
            joke1.SetActive(true);
            joke2.SetActive(true);
            joke3.SetActive(false);
        }
        else if (jokes_count == 3)
        {
            joke1.SetActive(true);
            joke2.SetActive(true);
            joke3.SetActive(true);
        }
        else
        {
            joke1.SetActive(false);
            joke2.SetActive(false);
            joke3.SetActive(false);
        }
    }

    private void randomiser()
    {
        randnum = Random.Range(0, 8);
        loader.jokelist(randnum);
        
    }

    public void addjoke()
    {
        jokes[jokes_count] = ScriptableObject.CreateInstance<Joke>();
        jokes[jokes_count].setJoke(loader.numtojoke);
        jokes_count++;
        /*       print(jokes[jokes_count - 1].content);
               print(randnum);*/
        loader.other();

        randomiser();
    }

    public void removelast()
    {
        jokes[jokes_count -1] = null;
        jokes_count--;
    }
}