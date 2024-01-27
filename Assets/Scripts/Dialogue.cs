using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    //Fields
    //Window
    public GameObject dialogueWindow;
    //Indicator
    public GameObject dialogueIndicator;
    //Text 
    public TMP_Text diaglogueText;
    //Dialogue list
    private List<string> currentDialogue;

    private int DialogueID;
   
    //character index;
    private int textID;

    //Writing speed
    public float writingSpeed;

    //Started 
    private bool started;

    private bool waitForNext = false;


    private void Awake()
    {
        ToggleIndicator(false);
        ToggleWindow(false);
    }
    private void ToggleWindow(bool isToggled) 
    {
        dialogueWindow.SetActive(isToggled);
    }

    public void ToggleIndicator(bool isToggled)
    {
        dialogueIndicator.SetActive(isToggled);
    }

    //Start Dialogue
    public void StartDialogue() 
    {
        if (started) 
        {
            return;
        }
        started = true;
        //show the window
        ToggleWindow(true);
        //hide indicator
        ToggleIndicator(false);
        //start DialogueID at 0
        GetDialogue(0);
    }
    private void GetDialogue(int i) 
    {
        DialogueID = i;
        textID = 0;

        //clear the dialogue component text
        diaglogueText.text = string.Empty;

        //Start writing
        StartCoroutine(WritingWords());
    }
    //End Dialogue
    public void EndDialogue() 
    {
        started = false;
        waitForNext = false;
        StopAllCoroutines();
        //hide window
        ToggleWindow(false);
    }

    //Writing logic 

    IEnumerator WritingWords() 
    {
        string currentDialogue = this.currentDialogue[DialogueID];
        //Write the text
        diaglogueText.text += currentDialogue[textID];
        //Increse the textId
        textID++;

        // if sentence ended
        if(textID < currentDialogue.Length) 
        {
            //wait second
            yield return new WaitForSeconds(writingSpeed);

            StartCoroutine(WritingWords());
        }
        else 
        {
            waitForNext = true;
        }
      
    }

    private void Update()
    {

        if (!started) 
        {
            return;
        }

        if (waitForNext && Input.GetKeyDown(KeyCode.E)) 
        {
            waitForNext = false;
            DialogueID++;
            if(DialogueID < currentDialogue.Count) 
            {
                GetDialogue(DialogueID);
            }
            else
            {
                ToggleIndicator(true);
                EndDialogue();
            }
            
        }
    }

    public void SetDialogue(List<string>dialogue) 
    {
        currentDialogue = new List<string>(dialogue);
    }
}
