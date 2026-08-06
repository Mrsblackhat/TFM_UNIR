using Cinemachine;
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;

public class StartTimeline : MonoBehaviour
{
    [SerializeField] GameObject enemy;

    [SerializeField] string animationScene;
    bool activated = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            activated = true;
            StartCoroutine(AnimationSequence(collision.gameObject));
        }
    }

    IEnumerator AnimationSequence(GameObject playerGameObject)
    {
        playerGameObject.GetComponent<PlayerController>().enabled = false;

        AsyncOperation async = SceneManager.LoadSceneAsync(animationScene, LoadSceneMode.Additive);

        while (!async.isDone)
        {
            yield return null;
        }

        playerGameObject.GetComponent<SpriteRenderer>().flipX = true;
        PlayableDirector director = Object.FindAnyObjectByType<PlayableDirector>();
        if (director != null)
        {
            yield return new WaitForSeconds((float)director.duration);
        }
        else
        {
            yield return new WaitForSeconds(3f);
        }

        SceneManager.UnloadSceneAsync(animationScene);
        playerGameObject.GetComponent<SpriteRenderer>().flipX = false;
        playerGameObject.GetComponent<PlayerController>().enabled = true;

        enemy.SetActive(true);

        Destroy(gameObject);
    }
}
