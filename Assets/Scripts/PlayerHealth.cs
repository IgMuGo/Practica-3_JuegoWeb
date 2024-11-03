using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] ParticleSystem deathParticles;         //Referencia a las partículas de muertr
    SpriteRenderer playerRenderer;                          //Referencia al sprite Renderer del jugador
    PlayerShoot playerShoot;                                //Referencia al script de disparo del jugador
    PlayerMovement playerMovement;                          //Referencia al script de movimiento del jugador
    [SerializeField] GameManager gameManager;               //Referencia al gameManager
    [SerializeField] AudioSource audioSource;               //Referencia al AudioSource del jugador, para sonido de muerte
    [SerializeField] AudioClip deathSound;                  //Referencia al clip de audio de muerte del jugador
    [SerializeField] HitStop hitStop;                       //Referencia a la clase que para el tiempo durante uin instante
    [SerializeField] MusicFades musicPlayer;                //Referencia al reproductor de música
    [SerializeField] WhiteScreenController whiteScreen;     //Referencioa al objeto que genera un flash en la pantalla
    
    bool isDead = false;                                    //Variable que indica si el jugador a muerto

    //Asignación de referencias a otros componentes del objeto
    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerShoot = GetComponent<PlayerShoot>();
        playerRenderer = GetComponent<SpriteRenderer>();
    }

    //Colisiones
    private void OnTriggerEnter2D(Collider2D collision)
    {

        //Si el jugador no está muerto
        if (!isDead)
        {
            //Si colisiona con Enemigos o balas enemigas, llama a la función de muerte
            if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
            {
                Die();
            }
        }
        
    }

    private void Update()
    {
        //Si está muerto, y pulsa R, se reinicia el nivel
        if (isDead && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    //Función de muerte
    void Die()
    {
        isDead = true;                      //Se indica el estado en la variable
        
        //Se deshabilitan los scripts de disparo y de movimiento, y el spriteRenderer
        playerShoot.enabled = false;
        playerMovement.enabled = false;
        playerRenderer.enabled = false;

        //Se reproduce el sonido de muerte
        audioSource.clip = deathSound;
        audioSource.Play();

        //Se Reproducen las partículas de muerte, el flash, la parada de tiempo
        deathParticles.Play();
        whiteScreen.SetFlash();
        hitStop.StopTime(.1f);

        //Se llama a la pantalla de muerte y se baja el volumen de la musica
        gameManager.DeathScreen();
        musicPlayer.SetFade(2, .2f);

    }

}
