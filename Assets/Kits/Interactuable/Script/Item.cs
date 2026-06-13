using UnityEngine;

public class Item : MonoBehaviour, Interactuable
{
    bool pickedUp = false;

    public void Interactuar(GameObject playerGameObject)
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
}
