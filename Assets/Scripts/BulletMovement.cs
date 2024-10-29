using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] float velocity;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * velocity * Time.deltaTime);  
    }
}
