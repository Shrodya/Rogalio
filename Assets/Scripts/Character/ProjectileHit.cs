   using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHit : MonoBehaviour
{
    public float damage;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name != "Character" && collision.tag !="Projectile")
        {
            if(collision.GetComponent<RecievingDamage>() != null)
            {
                collision.GetComponent<RecievingDamage>().DealDamage(damage);
            }
        }
        if (collision.tag == "Border" || collision.tag == "Enemy"  || collision.tag == "Door")
        {
         Destroy(gameObject);
        }
    }
}
