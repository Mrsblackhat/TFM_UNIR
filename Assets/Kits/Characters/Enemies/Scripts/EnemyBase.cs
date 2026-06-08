using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBase : MonoBehaviour
{
    protected Transform target;
    protected NavMeshAgent agent;

    protected PlayerHide playerHide;
    protected Transform puntoInicialTarget;

    protected virtual void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        puntoInicialTarget = new GameObject("PuntoInicial_" + gameObject.name).transform;
        puntoInicialTarget.position = transform.position;
    }

    protected virtual void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    protected void BuscarPlayer()
    {
        if (playerHide != null) return;

        playerHide = FindFirstObjectByType<PlayerHide>();

        if (playerHide != null)
        {
            target = playerHide.transform;
        }
    }

    protected bool PlayerEscondido()
    {
        return playerHide != null && playerHide.estaEscondido;
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
