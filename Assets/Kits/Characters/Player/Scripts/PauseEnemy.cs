using UnityEngine;
using UnityEngine.AI;

public class PauseEnemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    private StalkerEnemy stalkerScript;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        stalkerScript = GetComponent<StalkerEnemy>();
    }

    public void pause()
    {
        stalkerScript.enabled = false;
        
        agent.isStopped = true;
        agent.velocity = Vector3.zero;

        animator.SetBool("Moving", false);
        animator.speed = 0f;
    }

    public void move()
    {
        stalkerScript.enabled = true;

        agent.isStopped = false;
        
        animator.speed = 1f; 
    }
}
