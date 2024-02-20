using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MoveAi : MonoBehaviour
{
    [Header("Movement")]
    public Transform target;

    public float nextWaypointDistance = 1.5f;

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

        InvokeRepeating("UpdatePath", 0f, 1.5f);
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

        float distance = Vector3.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

    }

    private void FixedUpdate()
    {
        float targetDistance = Vector3.Distance(rb.position, target.position);
        Debug.DrawLine(rb.position, target.position);
        Debug.Log(targetDistance);
        if (targetDistance > 1.5f)
        {
            Move(speed);
            rb.isKinematic = false;
            Rotate();

        }
        else
        {
            rb.isKinematic = true;
            Rotate();

        }

    }
    public void Move(float moveSpeed)
    {
        Vector3 direction = ((Vector3)path.vectorPath[currentWaypoint] - rb.position).normalized;
        rb.MovePosition(rb.position + direction * moveSpeed * Time.deltaTime);
    }

    void Rotate()
    {
        rb.transform.LookAt(target.position);
    }
}
