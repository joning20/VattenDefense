using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VattenVerk : MonoBehaviour
{
    public int Health;
    public TextMeshProUGUI healthText;
    public Canvas losingUI;
    public Canvas gameUI;

    void Start()
    {
        losingUI.enabled = false;
        gameUI.enabled = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
