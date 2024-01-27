using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowJokeUI : MonoBehaviour
{
    public GameObject joke_text;
    public GameObject counter_text;
    private TextMeshProUGUI text_comp;

    void Start()
    {
        SetCounter(0);
    }

    public void SetJoke(string s)
    {
        text_comp = joke_text.GetComponent<TextMeshProUGUI>();
        text_comp.text = s;
    }

    public void SetVisible(bool flag)
    {
        text_comp = joke_text.GetComponent<TextMeshProUGUI>();
        text_comp.enabled = flag;
    }

    public void SetCounter(int n)
    {
        text_comp = counter_text.GetComponent<TextMeshProUGUI>();
        text_comp.text = "Jokes: " + n;
    }
}
