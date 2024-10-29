using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStop : MonoBehaviour
{
    [SerializeField] CameraShake cameraShake;
    IEnumerator StopTimeCoroutine(float stopTime)
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(stopTime);
        cameraShake.shakeDuration = .15f;
        Time.timeScale = 1;
    }

    public void StopTime(float stopTime)
    {
        StartCoroutine(StopTimeCoroutine(stopTime));
    }
}
