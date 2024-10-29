using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Text scoreText;
    int currentScore;
    [SerializeField] GameObject worldCanvasPoints;
    [SerializeField] float comboTime;
    [SerializeField]int comboMultiplier;
    [SerializeField]float comboClock;
    [SerializeField] Text highScoreText, restartGameText;
    // Start is called before the first frame update
    private void Awake()
    {
        comboMultiplier = 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = currentScore.ToString();

        
    }

    private void Update()
    {
        if (comboClock > 0)
        {
            comboClock -= Time.deltaTime;
        }
        else
        {
            if (comboMultiplier > 1)
            {
                comboMultiplier=1;
            }
        }
    }



    public GameObject GetPlayer()
    {
        return player;
    }

    public void AddPoints(int points, Vector3 pos)
    {
        GetComponent<WhiteScreenController>().SetFlash();
        if (comboClock > 0)
        {
            if (comboMultiplier < 5)
            {
                comboMultiplier++;
            }
        }
        comboClock = comboTime;
        points *= comboMultiplier;
        currentScore += points;
        scoreText.text = currentScore.ToString();
        GameObject newCanvas=Instantiate(worldCanvasPoints, pos, Quaternion.identity);
        newCanvas.transform.localScale = new Vector3(transform.localScale.x +.25f * comboMultiplier, transform.localScale.y + .25f * comboMultiplier,1);
        newCanvas.GetComponent<WorldSpaceUI_Points>().SetPointsText(points);
    }

    public void DeathScreen()
    {
        if(PlayerPrefs.GetInt("Highest Score") < currentScore)
        {
            PlayerPrefs.SetInt("Highest Score", currentScore);
        }
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("Highest Score");
        highScoreText.enabled = true;
        restartGameText.enabled=true;
    }
}
