using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySimpleProjectile : MonoBehaviour
{
    public float damage;

   void OnTriggerEnter2D(Collider2D collision)
   {
        if (collision.tag != "Enemy" && collision.tag !="Projectile")
        {
            if(collision.tag == "Player")
            {
                PlayerStats.playerStats.DealDamage(damage);
            }
        }
        if (collision.tag == "Border" || collision.tag == "Player" || collision.tag == "Door")
        {
            Destroy(gameObject);
        }
   }
}
