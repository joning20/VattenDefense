using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MouzeTest : MonoBehaviour
{
    public Vector3 MousePos;
    public LayerMask CollisionLayer;
    public LayerMask NotCollisonLayer;
    public LayerMask TowerCollider;
    public VattenVerk vattenVerk;

    [SerializeField] float radiusCheck;
    [SerializeField] Transform MoveObject;
    [SerializeField] SpriteRenderer MoveMaterial;
    [SerializeField] bool Placeable = false;

    public AudioManager audioManager;

    public bool holdingTower = false;

    public GameObject TowerPrefab;

    public GameObject tower2Prefab;

    public bool placingbool;

    public bool soaptowerselected;
    public bool tower1selected;

    public Sprite Bubble;
    public Sprite Net;

    void Start()
    {
        radiusCheck = MoveObject.localScale.x / 2;
    }

    void Update()
    {
        if (holdingTower)
        {
            if (soaptowerselected)
            {
                MoveMaterial.sprite = Bubble;
            }

            else
            {
               // MoveMaterial.sprite 
            }

            MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            MoveObject.position = new Vector3(MousePos.x, MousePos.y, MoveObject.position.z);

            if (Physics2D.OverlapCircle(MoveObject.position, radiusCheck, CollisionLayer) && !Physics2D.OverlapCircle(MoveObject.position, radiusCheck, NotCollisonLayer) && !Physics2D.OverlapCircle(MoveObject.position, radiusCheck, TowerCollider))
            {
                MoveMaterial.color = Color.green;
                Placeable = true;
            }

            else
            {
                MoveMaterial.color = Color.red;
                Placeable = false;
            }

            //Placing

            if (Input.GetButtonDown("Fire1"))
            {

                Vector3 TowerPos = new Vector3(MousePos.x, MousePos.y, -5);

                if (Placeable)
                {
                    if (soaptowerselected)
                    {
                        Instantiate(TowerPrefab, TowerPos, transform.rotation);
                        vattenVerk.UpdateMoney(-100);
                    }
                    if (tower1selected)
                    {
                        Instantiate(tower2Prefab, TowerPos, transform.rotation);
                        vattenVerk.UpdateMoney(-200);
                    }
                    placing();

                    audioManager.PlayCashSound();
                    
                }
            }
        }

       
    }

    public void placing()
    {
        if (holdingTower == false)
        {
            if (soaptowerselected)
            {
                if (vattenVerk.Money > 99)
                {
                    holdingTower = true;
                    MoveMaterial.enabled = true;
                }
            }
            else if (tower1selected)
            {
                if (vattenVerk.Money > 199)
                {
                    holdingTower = true;
                    MoveMaterial.enabled = true;
                }
            }
        }
        else
        {
            holdingTower = false;
            MoveMaterial.enabled = false;
        }

    }

    public void soapTower()
    {
        soaptowerselected = true;
        tower1selected = false;
    }

    public void tower1Tower()
    {
        soaptowerselected = false;
        tower1selected = true;
    }
}
