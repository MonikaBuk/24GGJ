using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public float speed;
    public const float freeze_time = 10f;
    public float freeze_clock;
    private Vector2 direction;
    public Rigidbody2D rigidbody;
    private bool test;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        direction.y = 1f;
        direction.x = 0f;
    }

    // Update is called once per frame
    private void Update()
    {
        Move();  
        
    }
    void Move()
    {
        if(test)
        {
            this.gameObject.transform.position = new Vector2(transform.position.x, transform.position.y - (direction.y * speed * Time.deltaTime));
        }
        else if(!test)
        {
            this.gameObject.transform.position = new Vector2(transform.position.x, transform.position.y - (-direction.y * speed * Time.deltaTime));
        }  
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision");
        Debug.Log(direction.y);
        if (test)
        {
            test = false;
        }
        else
        {
            test = true;
        }

        //gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 1);
        //direction.y = -direction.y;
    }
}

