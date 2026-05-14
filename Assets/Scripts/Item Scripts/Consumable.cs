using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    [SerializeField] private ItemType item;

    protected int itemQuantity;
    public GameObject player;

    public enum ItemType
    {
        Ammunition,
        Flashlight,
        Heals,
        Lore
    }
    
    //call in visual script playercontroller
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Use();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Pickup();
        }
    }
    /*void OnCollisionEnter(Collider other)
    {
        if (other == Collider.Consumable)
        {
            Pickup();
        }
    }*/
    public virtual void Pickup()
    {
        
    }

    public virtual void Use()
    {
        
    }
}
