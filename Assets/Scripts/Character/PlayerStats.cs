using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats playerStats;

    public GameObject player;
    public Text healthText;
    public Slider HealthBar;

    public Text manaText;
    public Slider ManaBar;
    
    public float health; 
    public float maxHealth;

    public float mana;
    public float maxMana;
    public float manaRegen;

    public float cash;
    public Text cashText;


    void Awake()
    {
        if(playerStats != null)
        {
            Destroy(playerStats);
        }
        else 
        {
            playerStats=this;
        }
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        health = maxHealth;
        mana = maxMana;
        cash = 0;
        cashText.text = "0 Gold";
        SetHealthUI();
        SetManaUI();
        StartCoroutine(RegenrationOfMana());
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        CheckDeath();
        SetHealthUI();
    }
    public void HealCharacter(float heal)
    {
        health+=heal;
        CheckOverheal();
        SetHealthUI();
    }
    public void CheckOverheal()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
    private void CheckDeath()
    {
        if (health <= 0)
        {
            Destroy(player);
            SceneManager.LoadScene("Main Menu");
        }
    }
    float CalculateHealthPercentage()
    {
        return health / maxHealth;
    }
    private void SetHealthUI()
    {
        HealthBar.value = CalculateHealthPercentage();
        healthText.text = Mathf.Ceil(health).ToString() + " / " + Mathf.Ceil(maxHealth).ToString();
    }
    
    public void ManaSpend(float manaCost)
    {
        mana-=manaCost;
        SetManaUI();
    }
    private void SetManaUI()
    {
        ManaBar.value = CalculateManaPercentage();
        manaText.text = Mathf.Ceil(mana).ToString() + " / " + Mathf.Ceil(maxMana).ToString();
    }
    float CalculateManaPercentage()
    {
        return mana/maxMana;
    }
    private IEnumerator RegenrationOfMana()
    {
        yield return new WaitForSeconds(1f);
        if (mana<maxMana)
        {
            mana+=manaRegen;
        }
        CheckOvermana();
        SetManaUI();
        StartCoroutine(RegenrationOfMana());
    }
    private void CheckOvermana()
    {
        if (mana > maxMana)
        {
            mana = maxMana;
        }        
    }
    public void CashSpend(float cost)
    {
        cash -= cost;
        cashText.text = cash.ToString() + " Gold";
    }
    public void CashAdd(float additionalCash)
    {
        cash += additionalCash;
        cashText.text=cash.ToString() + " Gold";
    }
}
