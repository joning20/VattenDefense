using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fastScript : MonoBehaviour
{
    public GameObject fastEnemy;
    public List<GameObject> fastInstants;
    public bool moveFastBoi = false;
    public Vector3 startPos;
    public float speed;

    public bool spawnFastBoi = true;


    public bool wave1 = false;
    public int wave1counter;
    void Start()
    {
        startPos = new Vector3(-9.15f, 7.5f, -2.9f);
    }

    void FixedUpdate()
    {
    }


    public void spawnKemikalie()
    {
        GameObject kemikalieInstant = Instantiate(fastEnemy, startPos, Quaternion.identity);
        fastInstants.Add(kemikalieInstant);
    }

}
