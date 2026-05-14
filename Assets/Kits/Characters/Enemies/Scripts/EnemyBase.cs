using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] protected Transform target;

    protected NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    protected virtual void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (Vector2.Distance(target.position, transform.position) <= agent.stoppingDistance)
            {
                Debug.Log("Te pillé");
            }
        }
    }
}
