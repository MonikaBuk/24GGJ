using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{

    public Transform objectToFollow; 
    private NavMeshAgent agent;
    private bool faceLeft = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false; agent.updateUpAxis = false;
        agent.SetDestination(objectToFollow.position);
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

}


