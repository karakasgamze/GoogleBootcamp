using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public List<Transform> waypoints;
    private int currentWaypointIndex = 0; 
    private bool isPenaltyActive = false; 

    void Start()
    {
        if (waypoints.Count == 0)
        {
            Debug.LogError("Waypoints not assigned!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Waypoint"))
        {
            int waypointIndex = waypoints.IndexOf(other.transform);
            if (waypointIndex == currentWaypointIndex && !isPenaltyActive)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Count)
                {
                    currentWaypointIndex = 0;
                }
                Debug.Log("Waypoint " + currentWaypointIndex + " reached.");
            }
            else if (waypointIndex != currentWaypointIndex)
            {
                ActivatePenalty();
            }
        }
    }

    void ActivatePenalty()
    {
        isPenaltyActive = true;
        Debug.Log("Penalty! Return to waypoint " + (currentWaypointIndex + 1));
    }

    void Update()
    {
        if (isPenaltyActive)
        {
            if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 5f)
            {
                isPenaltyActive = false;
                Debug.Log("Next waypoint!");
            }
        }
    }

    public bool HasCompletedLap()
    {
        return !isPenaltyActive && currentWaypointIndex == 0;
    }
}
