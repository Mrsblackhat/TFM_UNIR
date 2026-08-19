using UnityEngine;

public class BrokenMirror : MonoBehaviour, Interactuable
{
    [SerializeField] GameObject finalTrigger;
    [SerializeField] ParticleSystem particles;

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    bool active = false;
    private void Update()
    {
        if (!active && particles.isStopped)
        {
            finalTrigger.SetActive(true);
            active = true;
        }
    }

    public void Interactuar(GameObject playerGameObject)
    {
        anim.SetTrigger("Break");
        particles.Play();
    }
}
