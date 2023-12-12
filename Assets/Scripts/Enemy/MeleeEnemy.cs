using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    public Transform Character;
    public float speed;
    public float damageOnTouch;
    // Start is called before the first frame update
    void Start()
    {
        Character = GameObject.FindWithTag("Player").transform; 

    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Character.transform.position, speed * Time.deltaTime);
    }
   void OnTriggerEnter2D(Collider2D other)
   {
        if(other.tag == "Player")
        {
            PlayerStats.playerStats.DealDamage(damageOnTouch);
        }
    }

}
