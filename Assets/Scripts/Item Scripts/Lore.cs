using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lore : Consumable
{
    [Header("This value should match the index of the intended text popup")]
    [SerializeField] private int loreDropIdentifier;
    [SerializeField] private List<String> TextList;
    private string text = "";

    public override void Pickup()
    {
        GrabText();
        UIController.Instance.UpdateTextBox(text);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            StartCoroutine(ResetText());
        }
    }

    private void GrabText()
    {
        if (loreDropIdentifier >= 0 && loreDropIdentifier <= TextList.Count)
        {
            text = TextList[loreDropIdentifier];
        }
        else
        {
            Debug.Log("index out of range rip");
        }
    }

    private IEnumerator ResetText()
    {
        yield return new WaitForSeconds(3f);

        text = "";
        UIController.Instance.UpdateTextBox(text);
    }
}
