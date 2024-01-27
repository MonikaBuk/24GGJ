using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigidbody;
    private Vector2 direction;

    public float freeze_clock;

    void Start()
    {
        freeze_clock = 0f;
    }

    void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        if (freeze_clock > 0f)
        {
            freeze_clock -= Time.deltaTime;
            rigidbody.velocity = new Vector2(0f, 0f);
        }

        else
        {
            Move();
        }
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

    public void FreezePlayer()
    {
        freeze_clock = 10f;
    }
}
