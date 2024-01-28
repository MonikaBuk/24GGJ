using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameButtonScript : MonoBehaviour
{
    [SerializeField] Button button;
    private void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        SceneManager.LoadScene("Cutscene");
    }

    
}
