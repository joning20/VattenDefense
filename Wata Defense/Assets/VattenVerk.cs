using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VattenVerk : MonoBehaviour
{
    public int Health;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DmgBuilding(int dmg)
    {
        Health -= dmg;
    }
}
