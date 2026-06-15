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

    protected override void LogicaEnemigo()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        BuscarPlayer();

        Move();
    }

    private void Move()
    {
        if(PlayerEscondido())
        {
            agent.SetDestination(puntoInicialTarget.position);
            return;
        }

        if (Vector2.Distance(target.position, this.transform.position) <= safeDistance)
        {
            agent.speed = safeSpeed;
        }
        else
        {
            agent.speed = originSpeed;
        }

        agent.SetDestination(target.position);

        anim.SetBool("Moving", !agent.isStopped);

        if (Mathf.Clamp(target.position.x - transform.position.x, -1, 1) < 0) transform.localScale = new Vector2(-1, 1);
        else transform.localScale = new Vector2(1, 1);
    }
}
