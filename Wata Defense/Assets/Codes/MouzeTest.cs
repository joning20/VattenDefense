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

    [SerializeField] float radiusCheck;
    [SerializeField] Transform MoveObject;
    [SerializeField] SpriteRenderer MoveMaterial;
    [SerializeField] bool Placeable = false;

    public GameObject TowerPrefab;

    void Start()
    {
        radiusCheck = MoveObject.localScale.x / 2;
    }

    void Update()
    {
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        MoveObject.position = new Vector3(MousePos.x, MousePos.y, MoveObject.position.z);

        if (Physics2D.OverlapCircle(MoveObject.position, radiusCheck, CollisionLayer) && !Physics2D.OverlapCircle(MoveObject.position, radiusCheck, NotCollisonLayer) && !Physics2D.OverlapCircle(MoveObject.position, radiusCheck, TowerCollider))
        {
            print("Placeable");
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

            print("Clicked");
            Vector3 TowerPos =new Vector3(MousePos.x, MousePos.y, -5);

            if (Placeable)
            {
                Instantiate(TowerPrefab, TowerPos, transform.rotation);
                print("Placed");
            }
        }
    }
}
