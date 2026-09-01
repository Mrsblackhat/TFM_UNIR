using Unity.VisualScripting;
using UnityEngine;

public class ParallaxOff : MonoBehaviour
{
    private void Awake()
    {
        GameObject objectParallax = GameObject.FindGameObjectWithTag("Parallax");
        objectParallax.GetComponentInChildren<SpriteRenderer>().enabled = false;
    }
}
