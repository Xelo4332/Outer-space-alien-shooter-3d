using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MoveAi : MonoBehaviour
{
    [Header("Movement")]
    public Transform target;

    public float nextWaypointDistance = 3f;

    public float speed;

    Path path;

    int currentWaypoint;
    bool reachedWaypoint;

    Seeker seeker;
    Rigidbody rb;

    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody>();

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    private void Update()
    {
        if (path == null)
            return;
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedWaypoint = true;
            return;
        }
        else
        {
            reachedWaypoint = false;
        }

        Vector3 direction = ((Vector3)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector3 force = direction * speed * Time.deltaTime;


        float distance = Vector3.Distance(rb.position, path.vectorPath[currentWaypoint]);
        float targetDistance = Vector3.Distance(rb.position, target.position);


        if (targetDistance >= 5)
        {
            rb.AddForce(force,ForceMode.Force);
            rb.isKinematic = false;

        }
        else
        {
            rb.isKinematic = true;
        }
        

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

    }
}
