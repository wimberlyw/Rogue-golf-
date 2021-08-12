using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointController : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    private Transform targetWaypoint;
    public int targetWaypointIndex, lastWaypointIndex;
    private float minDistance = .1f;
    private float movementSpeed = 1.5f;
    private float rotationSpeed = 1.5f;
    private float distanceToWaypoint;
    public bool goingForwards = true;

    // Start is called before the first frame update
    void Start()
    {
        targetWaypointIndex = 0;
        lastWaypointIndex = waypoints.Count-1; //the last waypoint in the list
        targetWaypoint = waypoints[targetWaypointIndex]; //start on the first waypoint
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 directiontoWaypoint = targetWaypoint.position - transform.position; //get the direction to the waypoint
        Quaternion rotationtoWaypoint = Quaternion.LookRotation(directiontoWaypoint); //get rotation to look at the waypoint
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationtoWaypoint, rotationSpeed*Time.deltaTime); //Slerp to that rotation
        
        Debug.DrawRay(transform.position, transform.forward *.9f, Color.green, 0f); //draw a green line forward
        Debug.DrawRay(transform.position, directiontoWaypoint, Color.red, 0f); //draw a red line to waypoint

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, movementSpeed * Time.deltaTime); //Move towards the target waypoint
        distanceToWaypoint = Vector3.Distance(transform.position, targetWaypoint.position); //get the distance from that waypoint
        UpdateTargetWaypoint(distanceToWaypoint); //check to see if we've arrived and update to a new waypoint
    }

     

    void UpdateTargetWaypoint(float currentDistance)
    {
        if(goingForwards) 
           {
            if(currentDistance <= minDistance) //If you're at a waypoint
            {
                if(targetWaypointIndex < lastWaypointIndex) //If that waypoint isn't the last one in the list
                {
                targetWaypointIndex++;  //Increment to the next waypoint
                }
                else
                {
                
                goingForwards = false; //go backwards
                }
            }    
        
        }
        
        if(!goingForwards)
        {
            if(currentDistance <= minDistance) //if you're at a waypoint
            {
                if(targetWaypointIndex > 0) //if you're not at the first waypoint
                {
                targetWaypointIndex--; //decrement to next waypoint
                }
                else
                {
                targetWaypointIndex++; //otherwise go forwads
                goingForwards = true;
                }
            }    
        }

        targetWaypoint = waypoints[targetWaypointIndex]; //set the current waypoint to be the index we're keeping track of
    }
}
