using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{


    //Duraci�n del temblor de c�mara
    public float shakeDuration = 0f;

    //Indica la cantidad m�xima de desplazamiento de la c�mara
    public float shakeAmount = 0.7f;


    Vector3 originalPos;


    private void Awake()
    {
        //Guardamos el vector de la posici�n original de la c�mara
        originalPos=transform.position;
    }

    void Update()
    {
        //La c�mara tiembla durante la duraci�n indicada, al terminar vielve a la posici�n original
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
