using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    //Fields
    //Window
    public GameObject dialogueWindow;
    //Indicator
    public GameObject dialogueIndicator;
    //KeyPrompt
    public GameObject dialoguePrompt;
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
        if (GameStartManager.StartDialogueEnded) 
        {
            ToggleWindow(false);
        }
        else 
        {
            ToggleWindow(true);
            StartDialogue();
        }

        
    }
    private void ToggleWindow(bool isToggled) 
    {
        dialogueWindow.SetActive(isToggled);
    }

    public void ToggleIndicator(bool isToggled)
    {
        dialogueIndicator.SetActive(isToggled);
    }

    public void TogglePrompt(bool isToggled)
    {
        dialoguePrompt.SetActive(isToggled);
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

        TogglePrompt(false);
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

        if (waitForNext) 
        {
            TogglePrompt(true);
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                waitForNext = false;
                TogglePrompt(false);
                DialogueID++;
                if(DialogueID < currentDialogue.Count) 
                {
                    GetDialogue(DialogueID);
                }
                else
                {
                    if (!GameStartManager.StartDialogueEnded) 
                    {
                        GameStartManager.StartDialogueEnded = true;
                    }
                    ToggleIndicator(true);
                    EndDialogue();
                    if(PlayerJokes.jokes_count >= 3) 
                    {
                        SceneManager.LoadScene("GameWon");
                    }
                }
            }
            
            
        }
    }

    public void SetDialogue(List<string>dialogue) 
    {
        currentDialogue = new List<string>(dialogue);
    }
}
