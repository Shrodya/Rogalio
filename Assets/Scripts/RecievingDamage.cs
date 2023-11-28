using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RecievingDamage : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public GameObject healthBar;
    public Slider healthBarSlider;
    // Start is called before the first frame update
    void Start()
    {
        health=maxHealth;
    }

    // Update is called once per frame
    public void DealDamage(float damage)
    {
        healthBar.SetActive(true);
        health -=damage;
        CheckDeath();
        healthBarSlider.value = CalculateHealthPercentage();
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
    private float CalculateHealthPercentage()
    {
        return (health / maxHealth);
    }
}
