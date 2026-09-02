using UnityEngine;

public class Door : LoadNextScene
{
    [SerializeField] ItemPosition[] itemPositions;
    [SerializeField] private Sprite puertaAbierta;
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        foreach (ItemPosition item in itemPositions)
        {
            item.OnCorrectPosition += CorrectPositionItem;
        }

        canChange = false;

        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    int nCorrectItems = 0;
    void CorrectPositionItem()
    {
        nCorrectItems++;

        if (nCorrectItems == itemPositions.Length)
        {
            audioSource.Play();
            spriteRenderer.sprite = puertaAbierta;
            canChange = true;
        }
    }
}
