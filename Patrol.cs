using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class Patrol : MonoBehaviour
{

    public Transform[] PatrolPoints;
    private int destPoint = 0;
    private NavMeshAgent NPC;
    public bool Repeat;


    void Start()
    {
        NPC = GetComponent<NavMeshAgent>();
        NPC.autoBraking = false;

        GotoNextDestination();
    }

    void GotoNextDestination()
    {
        
        // Check points are set
        if (PatrolPoints.Length == 0)
        {
            Debug.Log("No Patrol Points found for: " +NPC.name);
            return;
        }
        
        if (Repeat)
        {
             NPC.destination = PatrolPoints[destPoint].position;
             destPoint = (destPoint + 1) % PatrolPoints.Length;
        }
        else
        {
            if (destPoint <= PatrolPoints.Length -1)
            {
                NPC.destination = PatrolPoints[destPoint].position;
                destPoint = (destPoint + 1);
            }
            else
            {
                //Do something
                Destroy(gameObject);
            }
        }


    }


    void Update()
    {

        if (!NPC.pathPending && NPC.remainingDistance <= NPC.stoppingDistance)
        {
            GotoNextDestination();
        }
            
    }
}
