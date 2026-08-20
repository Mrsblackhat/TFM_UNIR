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

    public void Interactuar(GameObject playerGameObject)
    {
        anim.SetTrigger("Break");
        particles.Play();
    }

    public void ActivateWinGameObject()
    {
        finalTrigger.SetActive(true);
    }
}
