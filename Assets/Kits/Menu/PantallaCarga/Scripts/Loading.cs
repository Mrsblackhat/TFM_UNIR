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

    float timeOffset = 0.5f;
    IEnumerator WaitForScene()
    {
        yield return new WaitForSeconds(timeOffset);

        video.Pause();

        yield return new WaitForSeconds(timeOffset);

        video.Play();
    }
}
