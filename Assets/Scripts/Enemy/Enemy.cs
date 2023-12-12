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
    public float speed;
    public float damageOnTouch;
    // Start is called before the first frame update
    void Start()
    {
        Character = GameObject.FindWithTag("Player").transform; 
        StartCoroutine(ShootPlayer());

    }

    IEnumerator ShootPlayer()
    {
        yield return new WaitForSeconds(attackSpeed);

            GameObject spell = Instantiate(projectile, transform.position,Quaternion.identity) ;
            Vector2 myPos = transform.position;
            Vector2 targetPos = Character.position;
            Vector2 direction = (targetPos - myPos).normalized;
            spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            spell.GetComponent<EnemySimpleProjectile>().damage = Random.Range(minDamage,maxDamage);
            StartCoroutine(ShootPlayer());
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Character.transform.position, speed * Time.deltaTime);
    }
   void OnTriggerEnter2D(Collider2D collision)
   {
        if(collision.tag == "Player")
        {
            PlayerStats.playerStats.DealDamage(damageOnTouch);
        }
    }

}
