using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fountain : MonoBehaviour
{
    public float heal;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerStats.playerStats.HealCharacter(heal);
            Destroy(gameObject);
        }
    }   
}

