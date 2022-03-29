using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soaptowerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject soapObject;
    public CircleCollider2D ccollider;
    public Vector3 spawnPos;

    public List<GameObject> waterColliders;

    public bool foundPoint;

    public float spawnIntervall;

    public float startingIntervall;

    void Start()
    {
        StartCoroutine(Intervall(startingIntervall));
    }

    IEnumerator Intervall(float intervall)
    {
        yield return new WaitForSeconds(intervall);

        if (waterColliders.Count > 0)
        {
            var number = Random.Range(0, waterColliders.Count);

            Instantiate(soapObject, RandomPointInBounds(waterColliders[number].gameObject.GetComponent<Collider2D>().bounds), Quaternion.identity);

            StartCoroutine(Intervall(spawnIntervall));
        }

        
    }
    public Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "waterHitbox")
        {
            waterColliders.Add(collision.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
