using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    //Velocidad de movimiento
    [SerializeField] float velocity;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        //Desplaza el objeto contínuamente las unidades indicadas por velocity por segundo
        transform.Translate(Vector2.up * velocity * Time.deltaTime);  
    }
}
