using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
  public void LoadAgain()
    {
        PlayerJokes.jokes = new Joke[3];
        GameStartManager.StartDialogueEnded = false;
        PlayerJokes.jokes_count = 0;
        DialogueTrigger.DialoguAdded = false;
        SceneManager.LoadScene("Cutscene");
    }
}
