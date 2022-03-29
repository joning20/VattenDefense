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

    public bool holdingTower = false;

    public GameObject TowerPrefab;

    public bool placingbool;

    void Start()
    {
        radiusCheck = MoveObject.localScale.x / 2;
    }

    void Update()
    {
        if (holdingTower)
        {
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
                    Instantiate(TowerPrefab, TowerPos, transform.rotation);
                    placing();

                    vattenVerk.UpdateMoney(-100);
                }
            }
        }

       
    }

    public void placing()
    {
        if (holdingTower == false)
        {
            if (vattenVerk.Money > 99)
            {
                holdingTower = true;
                MoveMaterial.enabled = true;
            }
        }
        else
        {
            holdingTower = false;
            MoveMaterial.enabled = false;
        }

    }
}
