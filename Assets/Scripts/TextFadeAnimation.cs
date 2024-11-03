using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Mediante un temporizador, cambia el valor de opacidad en un texto para que este parpadee
public class TextFadeAnimation : MonoBehaviour
{
    Text currentText;                           //Referencia al texto
    [SerializeField] float animationLength;     //Indica el timepo de la "animacion"
    float timer;                                //Temporizador

    private void Awake()
    {
        currentText=GetComponent<Text>();
    }

    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        float alpha = Mathf.Lerp(0, 1, timer / animationLength);        //Indicamos el valor de la opacidad mediante interpolacion
        currentText.color = new Color(1,1,1,alpha);                     //Se la aplicamos al texto

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            timer = animationLength;
        }
    }
}
