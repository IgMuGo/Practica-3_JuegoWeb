using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] float maxAmmo;
    [SerializeField] float coolDown;
    float coolDownTimer =0;
    [SerializeField] float ammoPerSec;
    float currentAmmo;
    [SerializeField] Image ammoBar;
    // Start is called before the first frame update

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip shootSound;
    [SerializeField] Transform bulletPoint;


    void Start()
    {
        currentAmmo = maxAmmo;
        UpdateAmmo();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && coolDownTimer<=0)
        {
            Shoot();
        }

        if (currentAmmo < maxAmmo)
        {
            currentAmmo += ammoPerSec * Time.deltaTime;
            UpdateAmmo();
        }

        if (coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
        }
    }
    void Shoot()
    {
        if (currentAmmo >= 1 && coolDownTimer<=0)
        {
            PlayShootSFX();
            currentAmmo--;
            Instantiate(bullet, bulletPoint.position, Quaternion.identity);
            coolDownTimer = coolDown;
            
        }

    }

    public void AddAmmo(float amount)
    {
        currentAmmo += amount;
        if (currentAmmo > 10)
        {
            currentAmmo = 10;
            UpdateAmmo();
        }

    }

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

    void PlayShootSFX()
    {
        float pitch = Random.Range(.75f, 1.25f);
        audioSource.clip = shootSound;
        audioSource.pitch = pitch;
        audioSource.Play();
    }
}

