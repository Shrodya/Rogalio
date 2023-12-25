using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public GameObject Shop;
    public static bool inShop=false;

    // Start is called before the first frame update
    void Start()
    {
        Shop.SetActive(false);   
    }
    void Update()
    {
        if(Merchant.touched)
        {
            Shop.SetActive(true);
            Time.timeScale = 0;
            inShop=true;
        }
    }
    public void FirstBuy()
    {
    }
    public void SecondBuy()
    {
    }
    public void ThirdBuy()
    {
    }
    public void Exit()
    {
        Merchant.touched = false;
        Shop.SetActive(false);
        Time.timeScale = 1;
        inShop=false;
    }
}
