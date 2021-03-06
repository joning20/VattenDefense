using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kemikalieScript : MonoBehaviour
{
    public GameObject vattenVerk;

    public AudioManager audioManager;

    public Sprite dmgBarrel;

    //public enemyController enemyCont;

    public string direction;

    public float hp;

    public float speed = 0.1f;

    void Start()
    {
        vattenVerk = GameObject.FindWithTag("vattenverkHitbox");
        direction = "down";

        audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManager>();
    }

   
    void FixedUpdate()
    {        
        if (direction == "down")
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - speed, -2.9f);
        }
        if (direction == "right")
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + speed, gameObject.transform.position.y, -2.9f);
        }
        if (direction == "up")
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + speed, -2.9f);
        }
        
    }
    public void TakeDamage(float health, string type)
    {
        if (type == "soap")
        {
            hp = hp - health;

            audioManager.PlaySplashSound();

            if (hp < 51)
            {
                SpriteRenderer spriteRend = gameObject.GetComponent<SpriteRenderer>();
                spriteRend.sprite = dmgBarrel;
            }
            if (hp < 1)
            {
                Destroy(gameObject);

                vattenVerk.GetComponent<VattenVerk>().UpdateMoney(10f);
            }
        }
        if (type == "net")
        {
            hp = hp - health;
            if (hp < 1)
            {
                Destroy(gameObject);
                vattenVerk.GetComponent<VattenVerk>().UpdateMoney(10f);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "soap")
        {
            TakeDamage(50, "soap");
        }
        if (collision.gameObject.tag == "net")
        {
            TakeDamage(100, "net");
        }

        if (collision.gameObject.tag == "vattenverkHitbox")
        {
            VattenVerk vattenverk = collision.gameObject.GetComponent<VattenVerk>();

            if (vattenverk != null)
            {
                vattenverk.DmgBuilding(10);
                print("DAmaged");
            }
            else
            {
                print("NOT VATTENVERK");
            }

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
