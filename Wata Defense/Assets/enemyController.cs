using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public GameObject kemikalieEnemy;
    public List<GameObject> kemikalieInstants;
    public bool moveKemikalie = false;
    public Vector3 startPos;
    public float speed;

    public bool spawnKemikalier = true;

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
        kemikalieInstants.Add(kemikalieInstant);
    }
}
