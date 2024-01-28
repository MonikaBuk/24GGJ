using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{

    public Transform objectToFollow; 
    public const float freeze_time = 10f;
    private NavMeshAgent agent;
    private bool faceLeft = false;
    public float freeze_clock;
    private const float enemy_speed = 8f;
    public bool isFrozen = false;
    private Animator anim;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false; agent.updateUpAxis = false;
        agent.SetDestination(objectToFollow.position);
        anim = GetComponent<Animator>();

        freeze_clock = 0f;
        agent.speed = enemy_speed;
    }

    void FixedUpdate()
    {
        if (freeze_clock > 0f)
        {
            freeze_clock -= Time.deltaTime;
            agent.speed = 0f;
        }

        if (freeze_clock <= 0f)
        { 
            isFrozen = false;
            anim.SetFloat("Speed", 1f);
            agent.speed = enemy_speed;
            agent.SetDestination(objectToFollow.position);
        }

 
    }

    void Update()
    {
        
        if (agent.remainingDistance > 2)
        {
            agent.SetDestination(objectToFollow.position);
        }

        if (objectToFollow.position.x < agent.transform.position.x && !faceLeft)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            faceLeft = true;
        }
        
        else if ((objectToFollow.position.x > agent.transform.position.x) && faceLeft)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            faceLeft = false;
        }
    } 

    public void Freeze()
    {
        isFrozen = true;
        anim.SetFloat("Speed", 0f);
        freeze_clock = freeze_time;
       
    }
}
