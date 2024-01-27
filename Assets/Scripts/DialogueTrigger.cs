using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogueScript;
    private bool playerDectected;
    //Detect trigger with player
    //if detected show indicator
    
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
            dialogueScript.StartDialogue();
        }
    }
}
