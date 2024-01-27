using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject buttonPrompt;
    public bool isHoldingItem;
    public bool canOpen = false;

    // Start is called before the first frame update

    void Start()
    {
        buttonPrompt.GetComponent<Renderer>().enabled = false;

        int ran = Random.Range(0, 1);
        if (ran == 0 )
        {
            isHoldingItem = true;
        }
        else
        {
            isHoldingItem= false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        buttonPrompt.GetComponent<Renderer>().enabled = true;
        canOpen = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        buttonPrompt.GetComponent<Renderer>().enabled = false;
        canOpen= false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canOpen && Input.GetKeyDown("i"))
        {
            canOpen = false;
            if (isHoldingItem)
            {
                //playerJokes++
                isHoldingItem = false;
            }
            else
            {
                Debug.Log("Empty");
            }
        }
    }
}
