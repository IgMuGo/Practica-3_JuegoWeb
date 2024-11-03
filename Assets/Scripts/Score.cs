using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    [SerializeField] Text scoreText;        //Referencia a texto que muestra la puntuacion actual
    int currentScore;                       //Puntuacion actual
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = currentScore.ToString();   
    }

    //Al añadir puntos (por parámetro), se suma a la cantidad total y se actualiza el texto que muestra la puntuacion
    public void AddPoints(int points)
    {
        currentScore += points;
        scoreText.text=currentScore.ToString();
    }
}
