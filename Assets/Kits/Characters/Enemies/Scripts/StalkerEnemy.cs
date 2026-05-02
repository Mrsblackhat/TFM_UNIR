using System;
using UnityEngine;
using UnityEngine.AI;

public class StalkerEnemy : EnemyBase
{
    [SerializeField] float safeDistance = 7;
    [SerializeField] float safeSpeed = 1;
    private float originSpeed;

    protected override void Start()
    {
        base.Start();
        originSpeed = agent.speed;
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        Move();
    }

    private void Move()
    {
        if (Vector2.Distance(target.position, this.transform.position) <= safeDistance)
        {
            agent.speed = safeSpeed;
        }
        else
        {
            agent.speed = originSpeed;
        }

        agent.SetDestination(target.position);
    }
}
