using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyTruckCode : MonoBehaviour
{
    public Transform SpawnPoint;
    public Transform MoneyPoint;
    public GameObject MoneyTruck;
    public Vector3 Movepoint;

    public float speed;

    public bool Transporting;
    public bool WaitingForDelay = false;

    public float MoneyWorth;

    public float depositTime;
    public float nextMoneyTime;

    public VattenVerk vattenVerk;
    public AudioManager audioMan;

    // Start is called before the first frame update
    void Start()
    {
        MoneyTruck.transform.position = SpawnPoint.position;
        Movepoint = SpawnPoint.position;
        Transporting = true;
        MoneyWorth = 200f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!WaitingForDelay)
        {
            MoneyTruck.transform.position = Movepoint;

            if (Transporting)
            {
                if (Movepoint.x > MoneyPoint.position.x)
                {
                    Movepoint.x -= speed;
                }

                else
                {
                    StartCoroutine(Delayer(depositTime));
                    DepositCash();
                }
            }

            else
            {
                if (Movepoint.x < SpawnPoint.position.x)
                {
                    Movepoint.x += speed;
                }

                else
                {
                    StartCoroutine(Delayer(nextMoneyTime));
                }
            }
        }
    }

    IEnumerator Delayer(float time)
    {
        WaitingForDelay = true;

        yield return new WaitForSeconds(time);
        Transporting = !Transporting;
        Flip();

        WaitingForDelay = false;
    }

    public void Flip()
    {
        Vector3 flip = new Vector3(-MoneyTruck.transform.localScale.x, MoneyTruck.transform.localScale.y, MoneyTruck.transform.localScale.z);
        MoneyTruck.transform.localScale = flip;
    }

    public void DepositCash()
    {
        audioMan.PlayCashSound();
        audioMan.PlayCashSound();
        vattenVerk.UpdateMoney(MoneyWorth);
        MoneyWorth = 100f;
    }
}
