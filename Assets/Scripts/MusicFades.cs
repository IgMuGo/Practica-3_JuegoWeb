using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFades : MonoBehaviour
{
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(StartFade(3, 1));
    }


    public void SetFade(float duration, float targetVolume)
    {
        StartCoroutine(StartFade(duration, targetVolume));
    }

    IEnumerator StartFade(float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}
