using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitStop : MonoBehaviour
{
    [SerializeField] CameraShake cameraShake;

    //Corutina que pausa el juego durante 0.15 segundos
    IEnumerator StopTimeCoroutine(float stopTime)
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(stopTime);
        cameraShake.shakeDuration = .15f;   //También llama a la función de temblor de cámara
        Time.timeScale = 1;
    }

    //Función pública accesible desde otros objetos para inicializar la corutina
    public void StopTime(float stopTime)
    {
        StartCoroutine(StopTimeCoroutine(stopTime));
    }
}
