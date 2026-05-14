using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //singleton logic
    public static Inventory Instance { get; private set; }

    private List<string> items = new List<string>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); 
    }

    public int ammo;
    public int heals;
    public int keys;

    void Start()
    {
        ammo = 0;
    }
}
