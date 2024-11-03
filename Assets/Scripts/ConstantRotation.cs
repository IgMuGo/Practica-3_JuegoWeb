using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotation : MonoBehaviour
{
    //Indica la velocidad de rotaci�n
    [SerializeField] float rotSpeed;

    private void Awake()
    {
        //Decide aleatoriamente la direcci�n de la rotaci�n
        int i=Random.Range(0, 2);
        if (i == 1) { rotSpeed = -rotSpeed; }

    }

    void Update()
    {
        //rota el objeto continuamente
        transform.Rotate(0,0,rotSpeed*Time.deltaTime);
    }
}
