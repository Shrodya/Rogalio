using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySimpleAttack : MonoBehaviour
{
    public GameObject projectile;
    public Transform Character;
    public float minDamage;
    public float maxDamage;
    public float projectileForce;
    public float attackSpeed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootPlayer());

    }
    IEnumerator ShootPlayer()
    {
        yield return new WaitForSeconds(attackSpeed);
        if(Character != null)
        {
            GameObject spell = Instantiate(projectile, transform.position,Quaternion.identity) ;
            Vector2 myPos = transform.position;
            Vector2 targetPos = Character.position;
            Vector2 direction = (targetPos - myPos).normalized;
            spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            spell.GetComponent<EnemySimpleProjectile>().damage = Random.Range(minDamage,maxDamage);
            StartCoroutine(ShootPlayer());
       }
    }

}
