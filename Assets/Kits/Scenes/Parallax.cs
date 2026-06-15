using Unity.VisualScripting;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private void Awake()
    {
        GameObject objectParallax = GameObject.FindGameObjectWithTag("Parallax");
        objectParallax.GetComponentInChildren<SpriteRenderer>().enabled = true;
    }
}
