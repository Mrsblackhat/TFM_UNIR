using UnityEngine;
using UnityEngine.AI;

public class PauseEnemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    private StalkerEnemy stalkerScript;
    private PatrollingEnemy patrollingScript;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        stalkerScript = GetComponent<StalkerEnemy>();
        patrollingScript = GetComponent<PatrollingEnemy>();
    }

    public void pause()
    {
        if (stalkerScript != null)
        {
            stalkerScript.enabled = false;
        }

        if (patrollingScript != null)
        {
            patrollingScript.enabled = false;
        }

        agent.isStopped = true;
        agent.velocity = Vector3.zero;

        animator.SetBool("Moving", false);
        animator.speed = 0f;
    }

    public void move()
    {
        if (stalkerScript != null)
        {
            stalkerScript.enabled = true;
        }

        if (patrollingScript != null)
        {
            patrollingScript.enabled = true;
        }

        agent.isStopped = false;
        
        animator.speed = 1f; 
    }
}
