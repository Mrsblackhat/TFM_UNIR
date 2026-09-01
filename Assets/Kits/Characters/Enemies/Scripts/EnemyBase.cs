using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyBase : MonoBehaviour
{
    protected Transform target;
    protected NavMeshAgent agent;
    protected Animator anim;

    protected PlayerHide playerHide;
    protected Transform puntoInicialTarget;

    [Header("Daño")]
    //[SerializeField] protected float danho;
    [SerializeField] protected GameObject attackPoint;
    [SerializeField] protected float attackRange;
    [SerializeField] protected float attackDelay = 1f;
    protected bool canAttack = false;

    protected virtual void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

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
        bool debePararse = debePararsePorDialogo || DebePararse();

        if (debePararse)
        {
            agent.isStopped = true;
            agent.velocity = Vector3.zero;
        }
        else
        {
            agent.isStopped = false;
        }

        LogicaEnemigo();
    }

    protected abstract void LogicaEnemigo();

    protected virtual bool DebePararse()
    {
        return false;
    }

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

    protected abstract void Attack();

    protected bool PlayerEscondido()
    {
        return playerHide != null && playerHide.EstaEscondido;
    }

    protected IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(attackDelay);
        canAttack = false;
        attackPoint.SetActive(false);
    }
}
