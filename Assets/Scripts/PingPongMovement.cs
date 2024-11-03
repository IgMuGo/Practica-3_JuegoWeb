using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongMovement : MonoBehaviour
{
    [SerializeField] float xSpeed, amplitude;
    float xPos;
    [SerializeField] float ySpeed;

    //Aplica un movimiento horizontal de ida y vuelta constante en el objeto que lleve este script como componente
    void Update()
    {
        //Usa la función Mathf.PingPong para obtener una interpolación de ida y vuelta infinita
        xPos = Mathf.Lerp(-amplitude, amplitude, Mathf.PingPong(Time.time*xSpeed, 1));

        //Aplica el valor de esa interpolación a la posición del objeto
        transform.position = new Vector3(transform.position.x+(xPos*Time.deltaTime), transform.position.y+(ySpeed*Time.deltaTime), 0);
    }
}
