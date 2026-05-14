using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ammo : Consumable
{
    [SerializeField] private int lootQuantity = 3;
    //drag this prefab into this field
    [SerializeField] private GameObject thisThing;
    private int ammoInInventory;
    void Start()
    {
        ammoInInventory = Inventory.Instance.ammo;
    }

    void Update()
    {
        
    }
    public override void Pickup()
    {
        ammoInInventory += lootQuantity;
        Inventory.Instance.ammo = ammoInInventory;
        thisThing.SetActive(false);
    }

}
