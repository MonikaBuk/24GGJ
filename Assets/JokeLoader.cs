using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class JokeLoader : MonoBehaviour
{
    //public TMP_Text text;
    public string test;
    private List<string> jokeslist;
    private int joke_num;

/*    private void Awake()
    {
        text.SetText("Lol");
    }*/
    void Start()
    {
        jokeslist = new List<string> {"Deez", "Nuts", "Cat", "Catcam" };
    }

    // Update is called once per frame
    void Update()
    {
        joke_num = PlayerJokes.instance.jokes_count;
        print(joke_num);
    }

    public void jokelist(int id)
    {
        test = jokeslist[id];
        
    }
}
