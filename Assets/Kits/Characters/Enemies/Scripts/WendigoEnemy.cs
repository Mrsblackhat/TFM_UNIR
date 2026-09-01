using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class WendigoEnemy : StalkerEnemy
{
    public void Desaparecer()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        agent.isStopped = true;
        agent.velocity = Vector3.zero;
    }

    public void Reaparecer()
    {
        StartCoroutine(TiempoEspera());
    }

    IEnumerator TiempoEspera()
    {
        yield return new WaitForSeconds(2f);

        GetComponent<SpriteRenderer>().enabled = true;
        agent.isStopped = false;
    }
}
