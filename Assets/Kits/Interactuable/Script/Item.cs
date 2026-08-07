using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Item : MonoBehaviour, Interactuable
{
    [SerializeField] GameObject canvas;
    bool pickedUp = false;

    public void Interactuar(GameObject playerGameObject)
    {
        if (canInteract)
        {
            PlayerController player = playerGameObject.GetComponent<PlayerController>();

            if (!pickedUp)
            {
                pickedUp = true;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                player.PickUpItem(this);
            }
            else
            {
                pickedUp = false;
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                player.DropItem();
            }
        }
    }

    public void SetParent(Transform parent)
    {
        transform.SetParent(parent);
        transform.localPosition = Vector3.zero;
    }

    public void DropDown()
    {
        pickedUp = false;

        transform.SetParent(null);
    }

    bool canInteract = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canvas.SetActive(true);
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canvas.SetActive(false);
            canInteract = false;
        }
    }
}
