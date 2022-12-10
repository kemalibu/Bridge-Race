using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    private Animator animator;

    private bool running;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit))
            {
                running = true;
                agent.SetDestination(hit.point);
            }
        }

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            running = false;
        }
        else
        {
            running = true;
        }

        animator.SetBool("isRunning", running);
    }
}
