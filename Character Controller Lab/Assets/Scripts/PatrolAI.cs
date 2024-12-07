using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class PatrolAI : MonoBehaviour
{
    public Transform[] waypoints;
    private int currentWaypointIndex;
    private NavMeshAgent agent;
    public float turnDelay = 7f;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false; //Disables automatic rotation for 2D 

        if (waypoints.Length > 0)
        {
            agent.SetDestination(waypoints[0].position);
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
            //if (agent.remainingDistance <= agent.stoppingDistance)
           // {
                //currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
                //agent.SetDestination(waypoints[currentWaypointIndex].position);
           // }
           // else
           // {
                StartCoroutine(turnAround());
          //  }
    }
    private IEnumerator turnAround()
    {
        yield return new WaitForSeconds(turnDelay); //Wait specified time

        currentWaypointIndex = 1;
        agent.SetDestination(waypoints[currentWaypointIndex].position);

        yield return new WaitForSeconds(turnDelay); //Wait specified time
        
        currentWaypointIndex = 0;
        agent.SetDestination(waypoints[currentWaypointIndex].position);
        
        yield return new WaitForSeconds(turnDelay);
    }
}
