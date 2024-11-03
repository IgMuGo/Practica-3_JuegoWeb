using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //Cantidad de salid del enemigo
    [SerializeField] int health;
    
    //Indica la cantidad de munici�n devuelta al jugador al morir
    [SerializeField] int ammoReturn;

    //Cantidad de puntosd que suma al morir
    [SerializeField] int points;

    //Referencias necesarias a otros objetos
    GameManager gameManager;
    GameObject playerRef;
    EnemySpawner spawnerRef;
    [SerializeField] Animator anim;
    [SerializeField] GameObject deathParticles;
    HitStop hitstop;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {      
        //Al detectar colisi�n con balas del jugador... , , y 
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Destroy(collision.gameObject);  //destruye la bala del jugador
            health--;                       //pierde un pto de vida
            anim.Play("TakeDamage");        //reproduce la animaci�n de recibir da�o

            //Si sus puntos de vida llegan a 0 llama a la funci�n de Morir
            if (health <= 0)
            {
                Die();
            }
        }
    }

    //Esta funci�n es llamada desde el Spawner al crear el objeto, para establecer la referencia al game manager
    public void SetGameManagerRef(GameManager gameManagerRef)
    {
        gameManager = gameManagerRef;
    }

    //Esta funci�n es llamada desde el Spawner al crear el objeto, para establecer la referencia al Player
    public void SetPlayerRef(GameObject player)
    {
        playerRef = player;
    }

    void Die()
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);   //Instancia part�culas de muerte   
        gameManager.AddPoints(points, transform.position);                      //Llamada a la funci�n de a�adir puntos en el GameManager
        playerRef.GetComponent<PlayerShoot>().AddAmmo(ammoReturn);              //Devuelve munici�n al jugador
        spawnerRef.AddSpawnPoints(1);                                           //Devuelve un pto de instanciado al Spawner
        hitstop.StopTime(.1f);                                                  //Llama a la funci�n de parar el tiempo durante 0.1 segundos
        Destroy(this.gameObject);                                               //Destruye el objeto
    }

    public void DestroyOutOfBounds()
    {
        spawnerRef.AddSpawnPoints(1);
        Destroy(this.gameObject);
    }

    public void SetSpawnerRef(EnemySpawner spawner)
    {
        spawnerRef = spawner;
    }

    public void SetHitStop(HitStop newHitStop)
    {
        hitstop = newHitStop;
    }

}
