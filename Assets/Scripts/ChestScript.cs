using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Build;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject buttonPrompt;
    public bool isHoldingItem;
    public bool canOpen = false;
    public bool opened = false;

    public bool buttonHeldDown = false;
    public float timeHeldDown;

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
        if (!opened)
        {
            buttonPrompt.GetComponent<Renderer>().enabled = true;
            canOpen = true;
        }
        
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
            buttonHeldDown = true;

        }

        if (buttonHeldDown)
        {
            timeHeldDown += Time.deltaTime;
            if (timeHeldDown >= 3)
            {
                Open();
            }
            if (Input.GetKeyUp("i"))
            {
                buttonHeldDown = false;
                timeHeldDown = 0;
            }
           
        }

        
    }
    public void Open()
    {
        if (isHoldingItem)
        {
            GameObject.Find("Player").GetComponent<SimplePlayerMovement>().NumberOfJokes++; ;
            isHoldingItem = false;
        }
        else
        {
            Debug.Log("Empty");
        }
        opened = true;
        canOpen = false;
    }
}
