using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kemikalieScript : MonoBehaviour
{
    public enemyController EnemyController;

    public string direction;
    void Start()
    {
        direction = "down";
    }

   
    void FixedUpdate()
    {        
        if (direction == "down")
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.1f, -2.9f);
        }
        if (direction == "right")
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.1f, gameObject.transform.position.y, -2.9f);
        }
        if (direction == "up")
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.1f, -2.9f);
        }
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "vattenverkHitbox")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "gridHitbox")
        {
            direction = "right";
        }
        if (collision.gameObject.tag == "gridHitbox2")
        {
            direction = "up";
        }
        if (collision.gameObject.tag == "gridHitbox3")
        {
            direction = "right";
        }
        if (collision.gameObject.tag == "gridHitbox4")
        {
            direction = "down";
        }
    }
}
