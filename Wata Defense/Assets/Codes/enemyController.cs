using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public GameObject kemikalieEnemy;
    public bool moveKemikalie = false;
    public Vector3 startPos;
    public float speed;
    public fastScript fastScript;

    public bool spawnKemikalier = true;


    public bool wave1 = false;
    public int wave1counter;

    public int kemikalieCount = 0;
    void Start()
    {
        startPos = new Vector3(-9.15f, 7.5f, -2.9f);
    }

    void FixedUpdate()
    {
        if (spawnKemikalier)
        {
            StartCoroutine("Intervall");
        }

    }


    IEnumerator Intervall()
    {
        spawnKemikalier = false;
        yield return new WaitForSeconds(speed);
        spawnKemikalie();
        spawnKemikalier = true;
    }

    public void spawnKemikalie()
    {
        GameObject kemikalieInstant = Instantiate(kemikalieEnemy, startPos, Quaternion.identity);
        kemikalieCount++;

        if (!wave1)
        {
            if (kemikalieCount > 10 && speed > 2)
            {
                fastScript.spawnKemikalie();
                kemikalieCount = 0;
            }

            else if (kemikalieCount > 5 && speed < 2 && speed > 1.5)
            {
                fastScript.spawnKemikalie();
                kemikalieCount = 0;
            }

            else if (kemikalieCount > 1 && speed < 1.5)
            {
                fastScript.spawnKemikalie();
                kemikalieCount = 0;
            }
        }
    }

    public void UpdateSpeed()
    {

        if (speed > 2.7 && speed < 3)
        {
            wave1 = true;
        }
        if (wave1)
        {
            speed = 0.7f;
            wave1counter++;
        }
        if (wave1counter == 20 && wave1)
        {
            wave1 = false;
            speed = 2.7f;

        }
        if (wave1 == false)
        {
            if (speed > 3)
            {
                speed = speed - 0.1f;
            }
            else if (speed < 3 && speed > 1)
            {
                speed = speed - 0.005f;
            }
            else if (speed < 1)
            {
                speed = speed - 0.0001f;
            }

        }

    }
}
