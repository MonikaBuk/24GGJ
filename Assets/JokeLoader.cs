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

/*    private void Awake()
    {
        text.SetText("Lol");
    }*/
    void Start()
    {
        jokeslist = new List<string> {"your mom", "Bob", "Cat" };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void jokelist(int id)
    {
        test = jokeslist[id];
        
    }
}
