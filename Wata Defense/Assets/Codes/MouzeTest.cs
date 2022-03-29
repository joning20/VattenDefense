using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MouzeTest : MonoBehaviour
{
    public Vector3 MousePos;
    public LayerMask CollisionLayer;

    [SerializeField] float radiusCheck;
    [SerializeField] Transform MoveObject;
    [SerializeField] SpriteRenderer MoveMaterial;

    void Start()
    {
        radiusCheck = MoveObject.localScale.x / 2;
    }

    void Update()
    {
        MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        MoveObject.position = new Vector3(MousePos.x, MousePos.y, MoveObject.position.z);

        if (Physics2D.OverlapCircle(MoveObject.position, radiusCheck, CollisionLayer))
        {
            print("Placeable");
            MoveMaterial.color = Color.green;
        }

        else
        {
            MoveMaterial.color = Color.red;
        }
    }
}
