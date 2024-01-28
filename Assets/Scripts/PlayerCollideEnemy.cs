using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerCollideEnemy : MonoBehaviour
{
    public GameObject player;
    private AudioSource eAudio;
    public PlayerJokes jokes;
    public Transform chests;
    private Animator enemyanimator;
    private bool isFrozen;
    [SerializeField] Sprite ClosedChestSprite;


    private void Start()
    {
      
        eAudio = GetComponent<AudioSource>();
        enemyanimator = GetComponent<Animator>();
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            isFrozen = GetComponent<PlayerCollideEnemy>().isFrozen;
            enemyanimator.SetBool("ColidedWithPlayer", true);

            if (!isFrozen)
            {
                if (PlayerJokes.jokes_count > 0)
                {
                    Debug.Log("asd");
                    jokes.removelast();
                    addToEmptyChest();
                    enemyanimator.SetBool("HasJoke", true);
                }
                else
                {
                    enemyanimator.SetBool("HasJoke", false);
                    SceneManager.LoadScene("GameOver");
                    
                }

                //gameover

                
                // if player life > 0
                // player life--
                // else
                // game lose
                // return

                gameObject.GetComponent<EnemyFollow>().Freeze();
                Debug.Log("Freeze");
                eAudio.Play();
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            enemyanimator.SetBool("ColidedWithPlayer", false);
        }
    }

    private void addToEmptyChest()
    {
        GameObject[] chest_list = new GameObject[chests.childCount];
        int empty_chest_count = 0;

        for (int i = 0; i < chests.childCount; i++)
        {
            if (!chests.GetChild(i).GetComponent<ChestScript>().isHoldingItem)
            {
                chest_list[empty_chest_count] = chests.GetChild(i).gameObject;
                empty_chest_count++;
            }
        }

        if ( empty_chest_count <= 0)
        {
            // all chests are full
            return;
        }

        // Unity don't allow Random.Range(0, 0);
        else if (empty_chest_count > 1)
        {
            int a = Random.Range(0, empty_chest_count - 1);
            chest_list[a].GetComponent<ChestScript>().isHoldingItem = true;
            chest_list[a].GetComponent<ChestScript>().opened = false;
            chest_list[a].GetComponent<SpriteRenderer>().sprite = ClosedChestSprite;
            // do the close chest animation
        }
        
        else
        {
            chest_list[0].GetComponent<ChestScript>().isHoldingItem = true;
            chest_list[0].GetComponent<ChestScript>().opened = false;
            chest_list[0].GetComponent<SpriteRenderer>().sprite = ClosedChestSprite;
            // do the close chest animation
        }
    }
}
