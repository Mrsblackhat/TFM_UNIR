using UnityEngine;
using UnityEngine.AI;

public class WendigoEnemy : StalkerEnemy
{
    public void Desaparecer()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        agent.isStopped = true;
    }

    public void Reaparecer()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        agent.isStopped = false;
    }
}
