using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] Transform bulletSpawnPoint;    //Indica la posición de la que salen las balas
    [SerializeField] GameObject bullet;             //Referencia al objeto bala de enemigo
    [SerializeField] float cooldown;                //Indica el tiempo entre disparos
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ShootAfterCooldown");   //Inicia la corutina de disparo
    }

    //Corutina de disparo, llama a la función de disparo cada cierto tiempo
    IEnumerator ShootAfterCooldown()
    {
        //Debug.Log("Cooldown Started");
        yield return new WaitForSeconds(cooldown);
        Shoot();
        StartCoroutine(ShootAfterCooldown());
    }

    //Instancia una bala en la posición indicada
    void Shoot()
    {
        Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
    }
}
