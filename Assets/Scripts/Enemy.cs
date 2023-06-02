using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform player;
    private Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);

        if(Input.GetKey(KeyCode.LeftShift))
        {
            agent.speed = 1f;
            animator.speed = 0.2f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            agent.speed = 3.5f;
            animator.speed = 1f;
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Space))
        {
            agent.speed = 0.1f;
            animator.speed = 0.0999999999999999f;
        }
    }
}
