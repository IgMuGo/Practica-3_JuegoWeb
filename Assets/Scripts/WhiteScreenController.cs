using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Genera un flashazo en la pantalla mediante una imagen
public class WhiteScreenController : MonoBehaviour
{
    [SerializeField] float flashDuration;   //Duracion del flashazo
    [SerializeField] float flashAlpha;      //Opacidad máxima de la imagen
    [SerializeField] Image whiteScreen;     //Referencia a la imagen
    float timeRemaining;                    //Temporizador
                 


    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;

        }

        float currentAlpha = Mathf.Lerp(0, flashAlpha, timeRemaining / flashDuration);      //Interpolacion para calcular la opacidad
        whiteScreen.color=new Color(1,1,1,currentAlpha);                                    //Aplicar la opacidad a la imagen

    }

    //Se llama a esta funcion desde otros objetos para generar un nuevo flashazo
    public void SetFlash()
    {
        timeRemaining = flashDuration;
    }
}
