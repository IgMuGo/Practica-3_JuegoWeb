using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    [SerializeField] Text scoreText;
    int currentScore;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    public void AddPoints(int points)
    {
        currentScore += points;
        scoreText.text=currentScore.ToString();
    }
}
