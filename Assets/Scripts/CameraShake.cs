using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{


    //Duración del temblor de cámara
    public float shakeDuration = 0f;

    //Indica la cantidad máxima de desplazamiento de la cámara
    public float shakeAmount = 0.7f;


    Vector3 originalPos;


    private void Awake()
    {
        //Guardamos el vector de la posición original de la cámara
        originalPos=transform.position;
    }

    void Update()
    {
        //La cámara tiembla durante la duración indicada, al terminar vielve a la posición original
        if (shakeDuration > 0)
        {
            transform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = originalPos;
        }
    }
}
