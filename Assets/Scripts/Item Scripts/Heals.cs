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

        healthManager = FindObjectOfType<HealthManager>();

        UIController.Instance.UpdateHealsCount(healsInInventory);
    }
    public override void Pickup()
    {
        healsInInventory += 1;
        Inventory.Instance.heals = healsInInventory;

        UIController.Instance.UpdateHealsCount(healsInInventory);

        thisThing.SetActive(false);
    }

    public override void Use()
    {
        if (healsInInventory > 0 && healthManager.hp < 3)
        {
            healthManager.hp += 1;
            healsInInventory -= 1;
            Inventory.Instance.heals = healsInInventory;

            UIController.Instance.UpdateHealsCount(healsInInventory);
            UIController.Instance.UpdateHPCount(healthManager.hp);
        }
    }
}
