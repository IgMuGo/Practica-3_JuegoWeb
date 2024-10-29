using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet" || collision.gameObject.tag == "EnemyBullet")
        {
            Destroy(collision.gameObject); ;
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<EnemyHealth>().DestroyOutOfBounds();
        }
    }
}