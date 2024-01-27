using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollideEnemy : MonoBehaviour
{
    public GameObject player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            // if player life > 0
            // player life--
            // else
            // game lose
            // return

            gameObject.GetComponent<EnemyFollow>().Freeze();
            Debug.Log("Freeze");
        }
    }
}
