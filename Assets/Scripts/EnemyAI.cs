using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
   public GameObject target;

   public float speed = 200f;
   public float nextWaypointDistance = 3f;

   public Transform EnemyGFX;

   Path path;
   int currentWaypoint = 0;
   bool reachedEndOfPath = false;

   Seeker seeker;
   Rigidbody2D rb;

    private void Awake() {
        target = GameObject.Find("Player");
    }
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        seeker.StartPath(rb.position, target.transform.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path=p;
            currentWaypoint = 0;
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
        reachedEndOfPath = true;
        return;
        } else
        {  
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if (force.x >= 0.01f)
        {
            EnemyGFX.localScale = new Vector3(4f, 4f, 4f);
        } 
        else if (force.x <= -0.01f)
        {
            EnemyGFX.localScale = new Vector3(-4f, 4f, 4f);
        }
    }
}
