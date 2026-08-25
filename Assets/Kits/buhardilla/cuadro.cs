using UnityEngine;

public class cuadro : MonoBehaviour, Interactuable
{
    [SerializeField] private Animator animator;
    private bool yaInteractuo;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Interactuar(GameObject playerGameObject)
    {
        if (yaInteractuo) return;

        else
        {
            yaInteractuo = true;
            animator.SetTrigger("interactua"); 
        }
    }
}
