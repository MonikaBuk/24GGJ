using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject buttonPrompt;
    [SerializeField] GameObject chestObject;

    [SerializeField] Sprite OpenChestSprite;
    [SerializeField] Sprite ClosedChestSprite;

    Animator anim;
    public PlayerJokes jokes;

    public bool isHoldingItem;
    public bool canOpen = false;
    public bool opened = false;

    public bool buttonHeldDown = false;
    public float timeHeldDown = 0;


    // Start is called before the first frame update

    void Start()
    {
        anim = GetComponent<Animator>();
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
        

        if (canOpen && Input.GetKeyDown("e"))
        {
            anim.SetBool("OpeningBool", true);
            buttonHeldDown = true;
            
        }

        if (buttonHeldDown)
        {
            timeHeldDown += Time.deltaTime;
            if (timeHeldDown >= 3)
            {
                Open();
            }
            
           
        }
        if (Input.GetKeyUp("e"))
            {
                buttonHeldDown = false;
                anim.SetBool("OpeningBool", false);
                timeHeldDown = 0;
                
                
            }
        


    }
    public void Open()
    {
        
        if (isHoldingItem)
        {
            //GameObject.Find("Player").GetComponent<SimplePlayerMovement>().NumberOfJokes++;
            jokes.addjoke();
            isHoldingItem = false;
        }
        else
        {
           // Debug.Log("Empty");
        }
        opened = true;
        canOpen = false;
        anim.SetBool("OpeningBool", false);
        buttonPrompt.GetComponent<Renderer>().enabled = false;
        chestObject.GetComponent<SpriteRenderer>().sprite = OpenChestSprite;

    }

    public void ShutChest()
    {

    }
}
