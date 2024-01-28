using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class JokeLoader : MonoBehaviour
{
    public TMP_Text text;
    public GameObject jokeanim;
    public string numtojoke;
    private List<string> jokeslist;
    private int joketype;
    private bool existed;
    private int test;

/*    private void Awake()
    {
        text.SetText("Lol");
    }*/
    void Awake()
    {
        jokeslist = new List<string> {"A Blind Man Walks into a bar... And then a table... And then a chair", "Deez", "Why do Fish always sing off key?... You cant tuna fish", "Do you smoke or drink coffee?... I Drink It.", "How do you get a squirrel to like you?... Act like a nut.", "Why don't eggs tell jokes?... They'd crack each other up", "FOR THE BEANS", "Why couldn't the bicycle stand up by itself?... It was two tired.", "Dad, can you put the cat out?... I didn't know it was on fire." };
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            existed = false;
            if(jokeanim != null) 
            {
                jokeanim.SetActive(false);
            }
            TimeResume();
        }
        if(existed)
        {
            ZaWorldo();
        }
    }

    public void jokelist(int id)
    {
        numtojoke = jokeslist[id];

        joketype = id % 2;

    }

    public void other()
    {
        print(joketype);

        if (joketype == 0)
        {
            if (jokeanim != null)
            {
                jokeanim.SetActive(true);
            }

            text.SetText("Bad Joke Acquired");
            existed = true;
        }
        else if (joketype == 1)
        {
            //dad joke
            if (jokeanim != null)
            {
                jokeanim.SetActive(true);
            }
            text.SetText("Dad Joke Acquired");
            existed = true;
        }
        else
        {
            //deez
            if (jokeanim != null)
            {
                jokeanim.SetActive(true);
            }

            text.SetText("Dad Joke Acquired");
            existed = true;
        }
    }

    private void ZaWorldo()
    {
        Time.timeScale = 0;
    }
    private void TimeResume()
    {
        Time.timeScale = 1;
    }
}
