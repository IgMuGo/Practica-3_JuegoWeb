using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Componente de los textos qeu muestran la puntuación conseguida al morir un enemigo
public class WorldSpaceUI_Points : MonoBehaviour
{
    [SerializeField] Text pointsText;
    //Funcion que indica la cantidad de puntos que tiene que mostrar el textp
    public void SetPointsText(int points)
    {
        pointsText.text=points.ToString();
    }

    //Funcion que destruye el objeto, es llamada desde una animación
    public void DestroyGameObject()
    {
        Destroy(this.gameObject);
    }
}
