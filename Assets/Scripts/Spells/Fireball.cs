    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpell : MonoBehaviour
{
    public GameObject projectile;
    public float minDamage;
    public float maxDamage;
    public float manaCost;
    public float projectileForce;
    void Update()
    {   
        if(Input.GetMouseButtonDown(0) && PlayerStats.playerStats.mana >= manaCost)
        {
            PlayerStats.playerStats.ManaSpend(manaCost);
            GameObject spell = Instantiate(projectile,transform.position,Quaternion.identity);
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 myPosition = transform.position;
            Vector2 direction = (mousePosition - myPosition).normalized;
            spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            spell.GetComponent<ProjectileHit>().damage = Random.Range(minDamage,maxDamage);
        }

    }
}
