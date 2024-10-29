using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhiteScreenController : MonoBehaviour
{
    [SerializeField] float flashDuration;
    [SerializeField] float flashAlpha;
    [SerializeField] Image whiteScreen;
    float timeRemaining;
    bool shouldFlash;




    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;

        }

        float currentAlpha = Mathf.Lerp(0, flashAlpha, timeRemaining / flashDuration);
        whiteScreen.color=new Color(1,1,1,currentAlpha);

    }

    public void SetFlash()
    {
        timeRemaining = flashDuration;
    }
}
