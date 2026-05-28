using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class HealthManager : MonoBehaviour
{
    [SerializeField] GameObject monster;
    [SerializeField] int maxHP = 3;
    [SerializeField] float iFramesLength = 7f;
    [SerializeField] private Material bloodVignette;
    private bool invulnerable = false;
    public int hp;
    private int healsInInventory;
    // Start is called before the first frame update
    void Start()
    {
        hp = maxHP;
        UIController.Instance.UpdateHPCount(hp);

        healsInInventory = Inventory.Instance.heals; 

        bloodVignette.SetFloat("_ScreenIntesity", 0f);

        bloodVignette.SetColor("_Color", Color.red);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == monster && invulnerable == false)
        {
            StartCoroutine(IFrames(iFramesLength));
        
            hp -= 1;
            UIController.Instance.UpdateHPCount(hp);

            if (hp == 2)
            {
                bloodVignette.SetFloat("_ScreenIntesity", 0.5f);
            }
            else if (hp == 1)
            {
                bloodVignette.SetFloat("_ScreenIntesity", 0.75f);
            }
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

            StartCoroutine(VisualDamage());
            
            UIController.Instance.UpdateHealsCount(healsInInventory);
            UIController.Instance.UpdateHPCount(hp);
        }
    }

    private IEnumerator VisualDamage()
    {
        yield return new WaitForSeconds(0.5f);  
        bloodVignette.SetFloat("_ScreenIntesity", 0.5f);

        yield return new WaitForSeconds(0.5f);
        bloodVignette.SetFloat("_ScreenIntesity", 0.25f);

        yield return new WaitForSeconds(0.5f);
        bloodVignette.SetFloat("_ScreenIntesity", 0.0f);
    }
}
