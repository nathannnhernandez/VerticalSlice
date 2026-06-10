using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Heals : Consumable
{
    [SerializeField] private GameObject thisThing;
    private HealthManager healthManager;
    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
    }
    public override void Pickup()
    {
        Inventory.Instance.heals += 1;

        thisThing.SetActive(false);
    }

    public override void Use()
    {
        if (Inventory.Instance.heals > 0 && healthManager.hp < 3)
        {
            healthManager.hp += 1;
            Inventory.Instance.heals -= 1;

            UIController.Instance.UpdateHPCount(healthManager.hp);
        }
    }
}
