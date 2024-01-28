using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerMovement : MonoBehaviour
{
    public float speed;
    private float startspeed;
    public Rigidbody2D rigidbody;
    private Vector2 direction;
    //public int NumberOfJokes = 0;

    public float freeze_clock;

    private Animator animator;

    void Start()
    {
        freeze_clock = 0f;
        animator = GetComponent<Animator>();
        startspeed = speed;
    }

    void Update()
    {
        if(GameStartManager.StartDialogueEnded != null) 
        {
            if (GameStartManager.StartDialogueEnded) 
            {
                ProcessInputs();
            }
            
        }
    }

    private void FixedUpdate()
    {
        Move();
        if (freeze_clock > 0f)
        {
            freeze_clock -= Time.deltaTime;
        }
        if (freeze_clock <= 0f)
        {
            speed = startspeed;
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
        rigidbody.velocity = new Vector2(direction.x * speed, direction.y * speed);
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        if (direction.x != 0f)
        {
            animator.SetBool("GoingToSide", true);
        }
        else
        {
            animator.SetBool("GoingToSide", false);
        }
    }

    public void FreezePlayer()
    {
        freeze_clock = 10f;
    }
    private void OnCollisionExit2D(Collision2D collision)
    { 

        if (speed - 10 > 0)
        {
            if (collision.gameObject.CompareTag("Trap"))
            {
                freeze_clock = 10f;
                speed = speed / 2;
            }
        }

    }
}
