using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class FoxMoving : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;

    public GameObject target;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            agent.enabled = true;
            animator.SetInteger("status", 1); // start walking

        }
        if (agent.enabled)
        {
            agent.SetDestination(target.transform.position); // Here A* is used to get path to target
            //showing the path
            
        }
    }
}
