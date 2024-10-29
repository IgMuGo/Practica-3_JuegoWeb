using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    [SerializeField] GameManager gameManager;
    [SerializeField] float[] spawnPosX;
    [SerializeField] float timeBtwnWaves;
    [SerializeField] float waveClock;
    //Quitar Serialized
    [SerializeField] int spawnPoints;
    //Quitar serialized
    [SerializeField] int unlockedEnemyTypes;
    [SerializeField] HitStop hitStop;

    //IEnumerator waveCoroutine;

    private void Awake()
    {
        spawnPoints = 3;
        timeBtwnWaves = 5;
        unlockedEnemyTypes = 1;

    }

    // Start is called before the first frame update
    void Start()
    {


        StartCoroutine(ReduceTimeBtwnWaves());
        StartCoroutine(IncreaseSpawnPoints());

    }

    // Update is called once per frame
    void Update()
    {
        waveClock += Time.deltaTime;
        if (waveClock >= timeBtwnWaves)
        {
            SpawnWave_1();
            waveClock = 0;
        }

    }

    public void SpawnEnemy(float xPos)
    {
        int nextEnemyType=0;
        if(unlockedEnemyTypes > 1) { nextEnemyType = Random.Range(0, unlockedEnemyTypes); }
        GameObject newEnemy = Instantiate(enemies[nextEnemyType], new Vector3(xPos, transform.position.y, 0), Quaternion.identity);
        EnemyHealth enemyHealth = newEnemy.GetComponent<EnemyHealth>();
        enemyHealth.SetGameManagerRef(gameManager);
        enemyHealth.SetPlayerRef(gameManager.GetPlayer());
        enemyHealth.SetSpawnerRef(this);
        enemyHealth.SetHitStop(hitStop);

    }

    void SpawnWave_1()
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
             //List<int> usedSpawnPosX = new List<int>();
             for (int i = 0; i < spawnPosX.Length; i++)
             {


                 //Si no quedan spawnPoints rompemos bucle
                 if (spawnPoints <= 0  )
                 {
                     break;
                 }

                 SpawnEnemy(spawnPosX[i]);
                 spawnPoints--;



             }


         }

 

    }

    /*IEnumerator SpawnWave()
    {
        if (isSpawningWaves)
        {
            StopCoroutine(waveCoroutine);
        }
        isSpawningWaves = true;
        yield return new WaitForSeconds(timeBtwnWaves);
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
            //List<int> usedSpawnPosX = new List<int>();
            for (int i = 0; i < spawnPosX.Length; i++)
            {

                //Si no quedan spawnPoints rompemos bucle
                if (spawnPoints <= 0 )
                {
                    break;
                }
                
                SpawnEnemy(spawnPosX[i]);
                spawnPoints--;
                
               

            }

            
        }
        isSpawningWaves = false;
        StartCoroutine(SpawnWave());
    }*/

    public void AddSpawnPoints(int extraPoints)
    {
        spawnPoints += extraPoints;
    }

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

    IEnumerator IncreaseSpawnPoints()
    {
        yield return new WaitForSeconds(15);
        spawnPoints++;
        
        StartCoroutine(IncreaseSpawnPoints());

    }
}
