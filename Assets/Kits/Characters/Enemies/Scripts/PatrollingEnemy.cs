using UnityEngine;
using UnityEngine.AI;

public class PatrollingEnemy : EnemyBase
{
    [SerializeField] Transform[] patrollPoints;
    int pointIndex;

    [SerializeField] float detectionRadius = 5;

    bool playerDetected = false;

    protected override void LogicaEnemigo()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        BuscarPlayer();

        if(PlayerEscondido())
        {
            playerDetected = false;
        }
        else 
        { 
            CheckForPlayer();
        }

        if (!playerDetected) DecideNextPoint();

        Move();
    }

    private void DecideNextPoint()
    {
        if (transform.position == patrollPoints[pointIndex].position)
        {
            if (pointIndex < patrollPoints.Length - 1)
            {
                pointIndex++;
            }
            else
            {
                pointIndex = 0;
            }
        }
    }

    private void Move()
    {
        if (Vector2.Distance(target.position, this.transform.position) > detectionRadius)
        {
            playerDetected = false;
        }

        if (playerDetected)
        {
            agent.SetDestination(target.position);
        }
        else
        {
            agent.SetDestination(patrollPoints[pointIndex].position);
        }
    }

    void CheckForPlayer()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius);

        foreach (Collider2D col in colliders)
        {
            if (col.CompareTag("Player"))
            {
                Debug.Log("Te detecté");
                playerDetected = true;
            }
        }
    }
}
