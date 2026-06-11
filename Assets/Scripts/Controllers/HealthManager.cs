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

        bloodVignette.SetColor("_Color", Color.red);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == monster && invulnerable == false)
        {
            StartCoroutine(IFrames(iFramesLength));
            if (hp > 0)
            {
                hp -= 1; 
            }
            UIController.Instance.UpdateHPCount(hp);

            StartCoroutine(VisualDamage());
        }
    }
    void Update()
    {
        healsInInventory = Inventory.Instance.heals; 
        if (Input.GetKeyDown(KeyCode.H))
        {
            UseHeals();
        }
        if (hp <= 0)
        {
            hp = 3;
            UIController.Instance.UpdateHPCount(hp);

            GameController.Instance.deaths += 1;

            if (Inventory.Instance.ammo < 3)
            {
                Inventory.Instance.ammo = 3;
            }

            transform.position = GameController.Instance.RespawnPos;
        }
        if (hp == maxHP)
        {
            bloodVignette.SetFloat("_ScreenIntensity", 0f);
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
        if(Inventory.Instance.heals > 0 && hp < 3)
        {
            hp += 1;
            Inventory.Instance.heals -= 1;

            StartCoroutine(VisualDamage());
            
            UIController.Instance.UpdateHPCount(hp);
        }
    }

    private IEnumerator VisualDamage()
    {
        bloodVignette.SetFloat("_ScreenIntensity", 0.75f);
        bloodVignette.SetFloat("_ScreenPower", 3f);

        yield return new WaitForSeconds(1f);
        bloodVignette.SetFloat("_ScreenIntensity", 0.5f);
        bloodVignette.SetFloat("_ScreenPower", 2f);

        yield return new WaitForSeconds(1f);
        bloodVignette.SetFloat("_ScreenIntensity", 0.25f);
        bloodVignette.SetFloat("_ScreenPower", 1f);

        yield return new WaitForSeconds(1f);
        bloodVignette.SetFloat("_ScreenIntensity", 0f);
        bloodVignette.SetFloat("_ScreenPower", 0f);
    }
}
