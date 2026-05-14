using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Heals : Consumable
{
    [SerializeField] private GameObject thisThing;
    private int healsInInventory;
    private HealthManager healthManager;
    void Start()
    {
        healsInInventory = Inventory.Instance.heals;
        Debug.Log(healsInInventory);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Use();
        }
    }
    public override void Pickup()
    {
        healsInInventory += 1;
        Inventory.Instance.heals = healsInInventory;
        Inventory.Instance.heals = healsInInventory;
        Debug.Log(healsInInventory);

        thisThing.SetActive(false);
    }

    public override void Use()
    {
        if (healsInInventory > 0 && healthManager.hp < 3)
        {
            healthManager.hp += 1;
            healsInInventory -= 1;
            Inventory.Instance.heals = healsInInventory;
            Debug.Log("heals " + healsInInventory);
            Debug.Log(healthManager.hp);
        }
    }

    ///hello
}
