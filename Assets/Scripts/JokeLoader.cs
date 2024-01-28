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

/*    private void Awake()
    {
        text.SetText("Lol");
    }*/
    void Awake()
    {
        jokeslist = new List<string> {"Dad Joke", "Deez", "Dad Joke", "Deez" };
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void jokelist(int id)
    {
        numtojoke = jokeslist[id];

        joketype = id % 2;

        if (joketype == 0) 
        {
            jokeanim.SetActive(true);
            text.SetText("Dad Joke");
        }
        else if (joketype == 1)
        {
            //dad joke
            jokeanim.SetActive(true);
            text.SetText("Dad Joke");
        }
        else
        {
            //deez
            jokeanim.SetActive(true);
            text.SetText("Bad Joke");
        }

    }
}
