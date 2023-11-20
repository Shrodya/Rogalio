using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecievingDamage : MonoBehaviour
{
    public float health;
    public float maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        health=maxHealth;
    }

    // Update is called once per frame
    public void DeadDamage(float damage)
    {
        health -=damage;
        CheckDeath();
    }

    private void CheckOverheal()
    {
        if(health > maxHealth)
        {
            health=maxHealth;
        }
    }
    
    private void CheckDeath()
    {
        if(health<=0)
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
    }
}
