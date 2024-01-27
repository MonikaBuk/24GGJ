using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Vector2 direction;
    public float speed = 100f;
    public Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        direction.x = 0f;
        direction.y = 1f;
    }

    // Update is called once per frame
    void Update()
    {   
        
        Move();
    }
    void Move()
    {
        rigidbody.velocity = new Vector2(direction.x * speed, direction.y * speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        direction.y = -1;
    }
}
