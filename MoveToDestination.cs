using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToDestination : MonoBehaviour
{

    // Use this for initialization
    private NavMeshAgent npc;
    public Transform goal;

    void Start()
    {
        npc = GetComponent<UnityEngine.AI.NavMeshAgent>();
        npc.destination = goal.position;
        CharacterTowardDestination();
        
    }

    // Update is called once per frame
    void Update()
    {
        CharacterTowardDestination();
    }

    public void CharacterTowardDestination()
    {
        if (!npc.pathPending && npc.remainingDistance <= npc.stoppingDistance)
        {
            //Do something
            //Destroy(gameObject);
            
        }
        else
        {
            UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            agent.destination = goal.position;
        }
    }
}
