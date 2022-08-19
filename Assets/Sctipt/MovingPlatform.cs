using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public List<Transform> waypoints;
    public float moveSpeed;
    public int targetIdx;

    void Start()
    {
        if (waypoints.Count == 1)
        {
            var startWaypoint = new GameObject("StartWaypoint");
            startWaypoint.transform.position = this.transform.position;
            waypoints.Insert(0, startWaypoint.transform);
        }
    }


    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[targetIdx].position, moveSpeed * Time.deltaTime);
    }

    void Update()
    {
        if (transform.position == waypoints[targetIdx].position)
        {
            if (targetIdx == waypoints.Count - 1)
            {
                targetIdx = 0;
            }
            else
            {
                targetIdx++;
            }
        }
    }
}
