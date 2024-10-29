using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotation : MonoBehaviour
{
    [SerializeField] float rotSpeed;

    private void Awake()
    {
        int i=Random.Range(0, 2);
        if (i == 1) { rotSpeed = -rotSpeed; }

    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,rotSpeed*Time.deltaTime);
    }
}
