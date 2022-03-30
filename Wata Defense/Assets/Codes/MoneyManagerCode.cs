using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyManagerCode : MonoBehaviour
{
    public int Money;
    [SerializeField] TextMeshProUGUI MoneyText;
    public AudioManager audioManager;

    void Start()
    {
        MoneyText.text = "Money: " + Money;
    }

    // Update is called once per frame
    void Update()
    {
        //radera detta 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddMoney(10);
        }
    }

    public void AddMoney(int money)
    {
        audioManager.PlayCashSound();
        Money += money;
        MoneyText.text = "Money: " + Money;
    }
}
