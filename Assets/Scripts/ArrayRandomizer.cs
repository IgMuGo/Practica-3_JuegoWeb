using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayRandomizer : MonoBehaviour
{
    [SerializeField] int[] numbers;
    // Start is called before the first frame update
    void Start()
    {
        for (int t = 0; t < numbers.Length; t++)
        {
            int tmp = numbers[t];
            int r = Random.Range(t, numbers.Length);
            numbers[t] = numbers[r];
            numbers[r] = tmp;
        }

        Debug.Log(numbers);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
