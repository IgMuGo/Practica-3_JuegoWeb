using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int ammoReturn;
    GameManager gameManager;
    GameObject playerRef;
    EnemySpawner spawnerRef;
    [SerializeField] Animator anim;
    [SerializeField] GameObject deathParticles;
    HitStop hitstop;
    [SerializeField] int points;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Destroy(collision.gameObject);
            health--;
            anim.Play("TakeDamage");
            if(health <= 0)
            {
                Die();
            }
        }
    }

    public void SetGameManagerRef(GameManager gameManagerRef)
    {
        gameManager = gameManagerRef;
    }

    public void SetPlayerRef(GameObject player)
    {
        playerRef = player;
    }

    void Die()
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        gameManager.AddPoints(points, transform.position);
        playerRef.GetComponent<PlayerShoot>().AddAmmo(ammoReturn);
        spawnerRef.AddSpawnPoints(1);
        hitstop.StopTime(.1f);
        Destroy(this.gameObject);
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
