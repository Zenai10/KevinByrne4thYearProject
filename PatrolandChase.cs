using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class PatrolandChase : MonoBehaviour
{

    public Transform[] PatrolPoints;
    public float ChaseRadius;
    private int destPoint = 0;
    private NavMeshAgent NPC;
    public Transform ChaseTarget;


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
            Debug.Log("No Patrol Points found for: " + NPC.name);
            return;
        }

        if (Repeat)
        {
            NPC.destination = PatrolPoints[destPoint].position;
            destPoint = (destPoint + 1) % PatrolPoints.Length;
        }
        else
        {
            if (destPoint <= PatrolPoints.Length - 1)
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
        float dist = Vector3.Distance(NPC.transform.position, ChaseTarget.position);
        Debug.Log(dist);
        if (dist <= ChaseRadius)
        {
            
            NPC.destination = ChaseTarget.position;

        }
        else
        {
            NPC.destination = PatrolPoints[destPoint].position;
            if (!NPC.pathPending && NPC.remainingDistance <= NPC.stoppingDistance)
            {
              
                GotoNextDestination();
            }
        } 


    }
}
