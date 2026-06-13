using UnityEngine;

public class BackgroundEffect : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(0, 0, 100 * Time.deltaTime);
    }
}
