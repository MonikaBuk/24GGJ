using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogueScript;
    private bool playerDectected;

    public List<string> dialogue_start;
    public List<string> dialogue_hint;
    public List<string> dialogue_notEnough;
    //winDialogue list 
    public List<string> dialogues_win;
    private static Joke[] jokesw;
    public static bool DialoguAdded = false;

    //Detect trigger with player
    //if detected show indicator
    private void Awake()
    {
        dialogueScript.SetDialogue(dialogue_start);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player") 
        {
            playerDectected = true;
            dialogueScript.ToggleIndicator(playerDectected);
        }
    }
    //else hide indicator
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerDectected = false;
            dialogueScript.ToggleIndicator(playerDectected);
            dialogueScript.EndDialogue();
        }
    }

    //while detected if interact start dialogue
    private void Update()
    {
        if(playerDectected && Input.GetKeyDown(KeyCode.E)) 
        {
            if (PlayerJokes.jokes_count < 1)
            {
                dialogueScript.SetDialogue(dialogue_hint);
            }
            if (PlayerJokes.jokes_count >= 1 && PlayerJokes.jokes_count < 3) 
            {
                dialogueScript.SetDialogue(dialogue_notEnough);
            }
            if(PlayerJokes.jokes_count >= 3) 
            {
                if (!DialoguAdded) 
                {
                    dialogues_win.Add("You got 3 jokes");
                    dialogues_win.Add("Let me see the first joke");
                    dialogues_win.Add(PlayerJokes.jokes[0].content);
                    dialogues_win.Add("AHAHAHAHAHAHAHAHAHAHAHAHAHAH");
                    dialogues_win.Add(PlayerJokes.jokes[1].content);
                    dialogues_win.Add("AHAHAHAHAHAHAHAHAHAHAHAHAHAH");
                    dialogues_win.Add(PlayerJokes.jokes[2].content);
                    dialogues_win.Add("AHAHAHAHAHAHAHAHAHAHAHAHAHAH");
                    dialogueScript.SetDialogue(dialogues_win);
                    DialoguAdded = true;
                }
            }
            dialogueScript.StartDialogue();
        }
    }
}
