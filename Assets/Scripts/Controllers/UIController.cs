using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ammoCount;
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
}
