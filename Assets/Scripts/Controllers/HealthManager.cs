using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class HealthManager : MonoBehaviour
{
    [SerializeField] GameObject monster;
    [SerializeField] int maxHP = 3;
    [SerializeField] float iFramesLength = 7f;
    private bool invulnerable = false;
    public int hp;
    private int healsInInventory;
    // Start is called before the first frame update
    void Start()
    {
        hp = maxHP;
        UIController.Instance.UpdateHPCount(hp);

        healsInInventory = Inventory.Instance.heals;        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == monster && invulnerable == false)
        {
            StartCoroutine(IFrames(iFramesLength));
            hp -= 1;
            UIController.Instance.UpdateHPCount(hp);
        }
    }
    void Update()
    {
        healsInInventory = Inventory.Instance.heals; 
        if (Input.GetKeyDown(KeyCode.H))
        {
            UseHeals();
        }
    }
    IEnumerator IFrames(float delay)
    {
        invulnerable = true;
        
        yield return new WaitForSeconds(delay);

        invulnerable = false;
    }

    private void UseHeals()
    {
        if(healsInInventory > 0 && hp < 3)
        {
            hp += 1;
            healsInInventory -= 1;
            
            UIController.Instance.UpdateHealsCount(healsInInventory);
            UIController.Instance.UpdateHPCount(hp);
        }
    }
}
