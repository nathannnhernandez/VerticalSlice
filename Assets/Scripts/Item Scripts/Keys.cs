using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : Consumable
{
    [SerializeField] private GameObject thisThing;
    public override void Pickup()
    {
        StartCoroutine(KeyText());


        Inventory.Instance.keys += 1;

    }

    private IEnumerator KeyText()
    {
        UIController.Instance.UpdateTextBox("Keys + 1");

        yield return new WaitForSeconds(3);

        UIController.Instance.UpdateTextBox("");
        
        thisThing.SetActive(false);


    }
}
