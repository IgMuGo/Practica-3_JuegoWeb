using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject bullet;         //Referencia a un Prefab de bala del jugador
    [SerializeField] float maxAmmo;             //IKndica la municion máxima
    [SerializeField] float coolDown;            //Indica el tiempo entre disparos
    float coolDownTimer =0;                     //Temporizador de disparos
    [SerializeField] float ammoPerSec;          //Indica cuanta munición se recupera por segundo
    float currentAmmo;                          //Indica la cantidad actual de munición
    [SerializeField] Image ammoBar;             //Referencia al elemento de interfaz qeu muestra la munición actual
    // Start is called before the first frame update

    [SerializeField] AudioSource audioSource;       //Referencia al AudioSource para reproducir sonidos de disparos
    [SerializeField] AudioClip shootSound;          //Referencia al AudioClip de sonido de dispoaro
    [SerializeField] Transform bulletPoint;         //Indica la posición en la que se instancian las balas


    void Start()
    {
        currentAmmo = maxAmmo;
        UpdateAmmo();
    }

    // Update is called once per frame
    void Update()
    {
        //Si pulsas Fire1(control izquierdo o click izdo) y el temporizador de disparo está a 0 se llama a la funcion de disparo
        if (Input.GetButton("Fire1") && coolDownTimer<=0)
        {
            Shoot();
        }

        //Si no tenemos el máximo de municion, recargamos la municion por segundo indicada
        if (currentAmmo < maxAmmo)
        {
            currentAmmo += ammoPerSec * Time.deltaTime;
            UpdateAmmo();       //Actualizamos el slider qeu muestra la munición
        }

        //Si el temporizador de disparo no está a 0 se reduce una unidad por segundo
        if (coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
        }
    }

    //Función de disparo
    void Shoot()
    {
        //Si tenemos munición y el temporizador está a 0
        if (currentAmmo >= 1 && coolDownTimer<=0)
        {
            PlayShootSFX();         //Reprodiucir sonido de disparo
            currentAmmo--;          //Gastar munición
            Instantiate(bullet, bulletPoint.position, Quaternion.identity);     //Instanciar bala
            coolDownTimer = coolDown;   //Reiniciar el temporizador de disparo
            
        }

    }

    //Funcion de añadir munición, se llama desde los enemigos al morir, para devlover municion al jugador
    public void AddAmmo(float amount)
    {
        currentAmmo += amount;
        if (currentAmmo > 10)
        {
            currentAmmo = 10;
            UpdateAmmo();
        }

    }

    //Actualiza el visualizador de municion
    void UpdateAmmo()
    {
        if (currentAmmo <= 0)
        {
            ammoBar.fillAmount = 0;
        }
        else
        {
            float fill = currentAmmo / maxAmmo;
            //Debug.Log(fill);
            ammoBar.fillAmount = Mathf.Lerp(0, 1, fill);
        }
    }

    //Funcion que reproduce el sonido de disparo
    void PlayShootSFX()
    {
        float pitch = Random.Range(.75f, 1.25f);    //Elige un pitch aleatorio entre dos valores definidos para añadir variedad

        //Reproduce el sonido de disparo con el pitch indicado
        audioSource.clip = shootSound;      
        audioSource.pitch = pitch;
        audioSource.Play();
    }
}

