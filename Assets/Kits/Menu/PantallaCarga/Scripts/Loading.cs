using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class Loading : MonoBehaviour
{
    VideoPlayer video;

    private void Awake()
    {
        video = GetComponent<VideoPlayer>();

        StartCoroutine(WaitForScene());
    }

    IEnumerator WaitForScene()
    {
        yield return new WaitForSeconds(0.5f);

        video.Pause();

        yield return new WaitForSeconds(0.5f);

        video.Play();
    }
}
