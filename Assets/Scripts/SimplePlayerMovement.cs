using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigidbody;
    private Vector2 direction;
    public int NumberOfJokes = 0;

    void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        Move();
    }


    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        direction = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rigidbody.velocity = new Vector2 (direction.x * speed, direction.y * speed);
    }
}
