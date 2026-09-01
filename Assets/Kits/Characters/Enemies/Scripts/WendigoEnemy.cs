using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class WendigoEnemy : EnemyBase, IAfectadoPorCamara
{
    [SerializeField] float safeDistance = 7;
    [SerializeField] float safeSpeed = 1;
    private float originSpeed;

    private float initialSafeSpeed;
    private float initialOriginSpeed;

    private bool desaparecido;


    protected override void Start()
    {
        base.Start();
        originSpeed = agent.speed;

        initialSafeSpeed = safeSpeed;
        initialOriginSpeed = originSpeed;
    }

    public void CambiarEstadoCamara(bool activa)
    {
        if (activa)
        {
            safeSpeed = initialSafeSpeed * 0.5f;
            originSpeed = initialOriginSpeed * 0.5f;
        }
        else
        {
            safeSpeed = initialSafeSpeed;
            originSpeed = initialOriginSpeed;
        }
    }

    protected override void LogicaEnemigo()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        BuscarPlayer();

        Move();
    }

    private void Move()
    {
        if (PlayerEscondido())
        {
            agent.SetDestination(puntoInicialTarget.position);
            return;
        }

        if (target != null)
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

            anim.SetBool("Moving", !agent.isStopped);

            if (Mathf.Clamp(target.position.x - transform.position.x, -1, 1) < 0) transform.localScale = new Vector2(-1, 1);
            else transform.localScale = new Vector2(1, 1);
        }
    }

    public void Desaparecer()
    {
        if (desaparecido) return;

        desaparecido = true;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        agent.isStopped = true;
        agent.velocity = Vector3.zero;
    }

    public void Reaparecer()
    {
        if (!desaparecido) return;

        desaparecido = false;

        StartCoroutine(TiempoEspera());
    }

    IEnumerator TiempoEspera()
    {
        yield return new WaitForSeconds(2f);

        GetComponent<SpriteRenderer>().enabled = true;
        agent.isStopped = false;
    }
}
