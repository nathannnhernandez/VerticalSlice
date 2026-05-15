using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ammoCount;
    [SerializeField] private TextMeshProUGUI healsCount;
    [SerializeField] private TextMeshProUGUI hpCount;
    [SerializeField] private TextMeshProUGUI crosshair;
    public static UIController Instance { get; private set; }

    private void Awake()
    {
       if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Destroy duplicate instances
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Persist across scenes
    }

    public void UpdateAmmoCount(int currentAmmo)
    {
        ammoCount.text = "Ammo: " + currentAmmo.ToString();
    }

    public void UpdateHealsCount(int currentHeals)
    {
        healsCount.text = "Heals: " + currentHeals.ToString();
    }

    public void UpdateHPCount(int currentHP)
    {
        hpCount.text = "HP: " + currentHP.ToString();
    } 


}
