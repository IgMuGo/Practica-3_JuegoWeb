using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] ParticleSystem deathParticles;
    SpriteRenderer playerRenderer;
    PlayerShoot playerShoot;
    PlayerMovement playerMovement;
    [SerializeField] GameManager gameManager;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip deathSound;
    [SerializeField] HitStop hitStop;
    [SerializeField] MusicFades musicPlayer;
    [SerializeField] WhiteScreenController whiteScreen;
    
    bool isDead = false;
    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerShoot = GetComponent<PlayerShoot>();
        playerRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isDead)
        {
            if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnemyBullet")
            {
                Die();
            }
        }
        
    }

    private void Update()
    {
        if (isDead && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void Die()
    {
        isDead = true;
        Debug.Log("PlayerDead");
        playerShoot.enabled = false;
        playerMovement.enabled = false;
        playerRenderer.enabled = false;
        audioSource.clip = deathSound;
        audioSource.Play();
        deathParticles.Play();
        whiteScreen.SetFlash();
        hitStop.StopTime(.1f);
        gameManager.DeathScreen();
        musicPlayer.SetFade(2, .2f);

    }

}
