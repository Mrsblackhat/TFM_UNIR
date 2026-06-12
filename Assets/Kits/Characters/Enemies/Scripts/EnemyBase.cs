using System;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyBase : MonoBehaviour
{
    protected Transform target;
    protected NavMeshAgent agent;

    protected PlayerHide playerHide;
    protected Transform puntoInicialTarget;

    [Header("Daño")]
    [SerializeField] protected float danho;

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

    protected virtual void Update()
    {
        bool debePararsePorDialogo = DialogoManager.HayDialogoAbierto;

        agent.isStopped = debePararsePorDialogo;

        if (debePararsePorDialogo)
        {
            agent.velocity = Vector3.zero;
            return;
        }

        LogicaEnemigo();
    }

    protected abstract void LogicaEnemigo();


    protected void BuscarPlayer()
    {
        if (playerHide != null)
        { return; }

        playerHide = FindFirstObjectByType<PlayerHide>();

        if (playerHide != null)
        {
            target = playerHide.transform;
        }
    }

    protected bool PlayerEscondido()
    {
        return playerHide != null && playerHide.EstaEscondido;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Danable>(out Danable danable))
        {
            if (Vector2.Distance(target.position, transform.position) <= agent.stoppingDistance)
            {
                Debug.Log("Te pillé");
                danable.DanarJugador(danho);
            }
        }
    }
}
