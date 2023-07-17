using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollwer : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;//setting the moving between two points
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;
    
    // Update is called once per frame
    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)// check the platform and currentWaypoint
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)// The size of waypoints array, if we at the last waypoint, then reset waypoints to 0
            {
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);// move current points to target points by deltatime without frame time
    }
}
