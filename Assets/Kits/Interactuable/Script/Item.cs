using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Item : MonoBehaviour, Interactuable
{
    [SerializeField] GameObject canvas;
    public bool canBePicked = true;
    public bool pickedUp = false;

    public void Interactuar(GameObject playerGameObject)
    {
        PlayerController player = playerGameObject.GetComponent<PlayerController>();

        if (!pickedUp && canBePicked && player.currentItem == null)
        {
            pickedUp = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            player.PickUpItem(this);
        }
        else if (pickedUp)
        {
            pickedUp = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            player.DropItem();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canBePicked && collision.CompareTag("Player"))
        {
            canvas.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (canBePicked && collision.CompareTag("Player"))
        {
            canvas.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (canBePicked && collision.collider.CompareTag("Player"))
        {
            canvas.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (canBePicked && collision.collider.CompareTag("Player"))
        {
            canvas.SetActive(false);
        }
    }
}
