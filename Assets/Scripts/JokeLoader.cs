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
        jokeslist = new List<string> {"Dad Joke", "Deez", "Better Dad Joke", "Deez Nuts" };
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
