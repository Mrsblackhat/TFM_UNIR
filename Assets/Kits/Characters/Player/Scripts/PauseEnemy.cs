using UnityEngine;
using UnityEngine.AI;

public class PauseEnemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    private EnemyBase enemy;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        enemy = GetComponent<EnemyBase>();
    }

    public void pause()
    {
        if (enemy != null)
        {
            enemy.enabled = false;
        }

        agent.isStopped = true;
        agent.velocity = Vector3.zero;

        animator.SetBool("Moving", false);
        animator.speed = 0f;
    }

    public void move()
    {
        if (enemy != null)
        {
            enemy.enabled = true;
        }

        agent.isStopped = false;
        
        animator.speed = 1f; 
    }
}
