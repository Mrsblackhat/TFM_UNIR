using UnityEngine;

public class CheckWin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //if (collision.GetComponent<PlayerController>().puzleCompleted)
            //{
                FinalMenu.instance.Win();
            //}
        }
    }
}
