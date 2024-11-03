using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;      //Array de los diferentes tipos de enemigos
    [SerializeField] GameManager gameManager;   //Referencia al GameManager
    [SerializeField] float[] spawnPosX;         //Array de posiciones de instanciado de enemigos (solo en horizontal)
    [SerializeField] float timeBtwnWaves;       //Indica el tiempo entre cada oleada de enemigos
    float waveClock;                            //Variable para temporizar el instanciado de enemigos
    int spawnPoints;                            //Indica cuantos enemigos puede haber en pantalla al mismo tiempo
    int unlockedEnemyTypes;                     //Indica que enemigos pueden ser instanciados a lo largo de la partida
    [SerializeField] HitStop hitStop;           //Referencia al script de parar el tiempo


    //Al iniciar se establecen los valores iniciales de instanciado
    private void Awake()
    {       
        spawnPoints = 3;            //3 enemigos por oleada en tres posiciones diferentes
        timeBtwnWaves = 5;          //Una oleada cada 5 segundos
        unlockedEnemyTypes = 1;     //Se desbloquea el primer tipo de enemigo

    }

    //Al iniciar se llama a las corutinas que aumentan la dificultad
    void Start()
    {
        StartCoroutine(ReduceTimeBtwnWaves());      //Esta reduce el tiempo entre oleadas
        StartCoroutine(IncreaseSpawnPoints());      //Esta incrementa el número de enemigos que puede haber en pantalla al mismo tiempo
    }

    // Update is called once per frame
    void Update()
    {
        //Temporizador, llama a la función de Instanciar oleada de enemigos cada cierto tiempo
        waveClock += Time.deltaTime;
        if (waveClock >= timeBtwnWaves)
        {
            SpawnWave();
            waveClock = 0;
        }

    }


    void SpawnWave()
    {

         if (spawnPoints > 0)
         {
             //Randomizamos el array de posiciones en x
             for (int t = 0; t < spawnPosX.Length; t++)
             {
                 float tmp = spawnPosX[t];
                 int r = Random.Range(t, spawnPosX.Length);
                 spawnPosX[t] = spawnPosX[r];
                 spawnPosX[r] = tmp;
             }
             
             //Bucle que llama a la función de instanciar enemigos en las posiciones indicadas
             for (int i = 0; i < spawnPosX.Length; i++)
             {


                 //Si no quedan spawnPoints rompemos bucle para dejar de instanciar enemigos
                 if (spawnPoints <= 0  )
                 {
                     break;
                 }

                 SpawnEnemy(spawnPosX[i]);
                 spawnPoints--;            
                //Cada enemigo instanciado gasta un punto, de modo que controlamos la cantidad de enemigos en pantalla
                //Al morir, los enemigos devuelven su punto, para poder seguir instanciando enemigos
             }
         }
    }

    //Función de instanciar enemigo, pide la posición horizontal de instanciado como parámetro
    public void SpawnEnemy(float xPos)
    {
        int nextEnemyType=0;
        if(unlockedEnemyTypes > 1) { nextEnemyType = Random.Range(0, unlockedEnemyTypes); }                                             //Decide el enemigo a instanciar aleatoriamente
        GameObject newEnemy = Instantiate(enemies[nextEnemyType], new Vector3(xPos, transform.position.y, 0), Quaternion.identity);     //Instancia el enemigo

        //Aplica las referencias en los enemigos a otros objetos con los qeu interactuan más adelante
        EnemyHealth enemyHealth = newEnemy.GetComponent<EnemyHealth>();                                                             
        enemyHealth.SetGameManagerRef(gameManager);                                                                 
        enemyHealth.SetPlayerRef(gameManager.GetPlayer());
        enemyHealth.SetSpawnerRef(this);
        enemyHealth.SetHitStop(hitStop);

    }

    //Esta función es llamada desde los enemigos al morir, devuelve puntos de instanciado
    public void AddSpawnPoints(int extraPoints)
    {
        spawnPoints += extraPoints;
    }

    //Esta corutina desbloquea un tipo de enemigo cada 30 segundos, hasta que se desbloquean todos los tipos de enemigos
    IEnumerator ReduceTimeBtwnWaves()
    {
        yield return new WaitForSeconds(30);
        if (unlockedEnemyTypes < enemies.Length)
        {
            unlockedEnemyTypes++;
        }
        if (timeBtwnWaves > 1) { timeBtwnWaves--; }
        else { StopCoroutine(ReduceTimeBtwnWaves()); }
        StartCoroutine(ReduceTimeBtwnWaves());
    }

    //Esta corutina añade un punto de instanciado cada 15 segundos, es decir
    //Cada 15 segundosse aumenta el numero máximo de enemigos en pantalla simultáneamente
    IEnumerator IncreaseSpawnPoints()
    {
        yield return new WaitForSeconds(15);
        spawnPoints++;
        
        StartCoroutine(IncreaseSpawnPoints());

    }
}
