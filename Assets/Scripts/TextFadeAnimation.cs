using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFadeAnimation : MonoBehaviour
{
    Text currentText;
    [SerializeField] float animationLength;
    float timer;

    private void Awake()
    {
        currentText=GetComponent<Text>();
    }

    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        float alpha = Mathf.Lerp(0, 1, timer / animationLength);
        currentText.color = new Color(1,1,1,alpha); 

        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = animationLength;
        }
    }
}
