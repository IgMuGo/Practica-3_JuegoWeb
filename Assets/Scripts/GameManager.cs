using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;                 //Referencia al jugador
    [SerializeField] Text scoreText;                    //Referencia al texto que muestra los puntos
    int currentScore;                                   //Puntos conseguidos en la partida actual
    [SerializeField] GameObject worldCanvasPoints;      //Referencia a prefab que se instancia cuando muere un enemigo y muestra los puntos conseguidos
    [SerializeField] float comboTime;                   //Indica el tiempo que se puede mantener un combo
    [SerializeField]int comboMultiplier;                //Indica el muyltiplicador de puntos por combo
    float comboClock;                                   //Temporizador para el combo
    [SerializeField] Text highScoreText, restartGameText;   //Referencias a textor que aparecen al morir
    // Start is called before the first frame update
    private void Awake()
    {
        comboMultiplier = 1;    //Inicializamos el multiplicador de combo a 1
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = currentScore.ToString();   
                
    }

    private void Update()
    {
        //Si el temporizador de combo llega a 0, se restablece el multiplicador a 1
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

    //Devuelve el objeto Player
    public GameObject GetPlayer()
    {
        return player;
    }

    //Funcion de añadir puntos, es llamada desde los enemigos cuando mueren
    public void AddPoints(int points, Vector3 pos)
    {
        //Llama a un objeto que genera un flash en la pantalla
        GetComponent<WhiteScreenController>().SetFlash();

        //Si estamos durante un combo, incrementa el multiplicador
        if (comboClock > 0)
        {
            if (comboMultiplier < 5)
            {
                comboMultiplier++;
            }
        }
        comboClock = comboTime;     //Restablece el temporizador de combo
        points *= comboMultiplier;  //Multiplica los puntos recibidos por el multiplicador de combo
        currentScore += points;     //Añade los puntos al marcador
        scoreText.text = currentScore.ToString();

        //Instancia el prefab que muestra los puntos conseguidos y le asigna los valores necesarios
        GameObject newCanvas =Instantiate(worldCanvasPoints, pos, Quaternion.identity);  
        newCanvas.transform.localScale = new Vector3(transform.localScale.x +.25f * comboMultiplier, transform.localScale.y + .25f * comboMultiplier,1);
        newCanvas.GetComponent<WorldSpaceUI_Points>().SetPointsText(points);
    }

    //Al morir el jugador...
    public void DeathScreen()
    {
        //Comprueba si se ha batido un nuevo record y lo almacena
        if(PlayerPrefs.GetInt("Highest Score") < currentScore)
        {
            PlayerPrefs.SetInt("Highest Score", currentScore);
        }

        //Muestra la puntuación histórica más alta, y el texto que indica cómo reiniciar la partida
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("Highest Score");
        highScoreText.enabled = true;
        restartGameText.enabled=true;
    }
}
