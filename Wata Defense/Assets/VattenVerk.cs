using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VattenVerk : MonoBehaviour
{
    public int Health;
    public float Money;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI healthText;
    public Canvas losingUI;
    public Canvas gameUI;

    void Start()
    {
        losingUI.enabled = false;
        gameUI.enabled = true;
        UpdateMoney(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateMoney(float money)
    {
        Money = Money + money;
        moneyText.text = "Money: " + Money.ToString();
    }
    public void DmgBuilding(int dmg)
    {

        if (Health > 0)
        {
            Health -= dmg;
            healthText.text = "Health: " + Health.ToString();
        }
        else if (Health == 0)
        {
            losingUI.enabled = true;
        }   

        
    }
}
