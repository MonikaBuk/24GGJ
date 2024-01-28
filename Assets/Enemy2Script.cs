using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public float speed;
    private Vector2 direction;
    public Rigidbody2D rigidbody;
    [SerializeField] GameObject enemy;
    

    // Start is called before the first frame update
    void Start()
    {
        direction.y = 1f;
        direction.x = 0f;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        enemy.transform.position = new Vector3(transform.position.x, transform.position.y - (direction.y * speed * Time.deltaTime), transform.position.z);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision");
        direction.y = -direction.y;
    }
}

