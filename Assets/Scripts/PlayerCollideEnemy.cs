using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollideEnemy : MonoBehaviour
{
    public GameObject player;
    private AudioSource audio;
    public PlayerJokes jokes;

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
            }
            else
            {
                Debug.Log("empty");
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
}
