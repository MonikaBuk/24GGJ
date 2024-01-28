using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollideEnemy : MonoBehaviour
{
    public GameObject player;
    private AudioSource audio;
    public PlayerJokes jokes;
    public Transform chests;


    [SerializeField] Sprite ClosedChestSprite;


    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            if (PlayerJokes.jokes_count > 0)
            {
                jokes.removelast();
                addToEmptyChest();

            }
            else
            {
                Debug.Log("empty");
                //gameover
            }
            // if player life > 0
            // player life--
            // else
            // game lose
            // return

            gameObject.GetComponent<EnemyFollow>().Freeze();
            Debug.Log("Freeze");
            audio.Play();
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
