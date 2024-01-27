using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowJokeUI : MonoBehaviour
{
    public GameObject child_text;
    private TextMeshProUGUI text_comp;

    void Start()
    {
        text_comp = child_text.GetComponent<TextMeshProUGUI>();
    }

    public void SetJoke(string s)
    {   
        text_comp.text = s;
    }

    public void SetVisible(bool flag)
    {
        text_comp.enabled = flag;
    }
}
