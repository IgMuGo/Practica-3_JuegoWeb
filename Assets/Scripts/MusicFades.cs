using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Este script sirve para realizar fades en los reproductores de m�sica mediante una corutina
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

    //Cambia el volumen del audiosource desde el volumen inicial hasta un valor pasado como par�metro
    //La duraci�n del fade tambi�n se indica como par�metro
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
