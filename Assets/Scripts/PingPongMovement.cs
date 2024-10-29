using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongMovement : MonoBehaviour
{
    [SerializeField] float xSpeed, amplitude;
    float xPos;
    [SerializeField] float ySpeed;

    void Update()
    {
        xPos = Mathf.Lerp(-amplitude, amplitude, Mathf.PingPong(Time.time*xSpeed, 1));
        transform.position = new Vector3(transform.position.x+(xPos*Time.deltaTime), transform.position.y+(ySpeed*Time.deltaTime), 0);
    }
}
