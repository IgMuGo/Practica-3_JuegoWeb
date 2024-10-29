using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] GameObject bullet;
    [SerializeField] float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ShootAfterCooldown");
    }


    IEnumerator ShootAfterCooldown()
    {
        //Debug.Log("Cooldown Started");
        yield return new WaitForSeconds(cooldown);
        Shoot();
        StartCoroutine(ShootAfterCooldown());
    }

    void Shoot()
    {
        Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
    }
}
