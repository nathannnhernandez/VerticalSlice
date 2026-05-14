using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //singleton logic
    public static GameController Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); 
        monster.SetActive(true);
    }
    [SerializeField] private GameObject monster;

    private bool monsterSpawned;
    void Start()
    {
        monsterSpawned = false;
        monster.SetActive(false);
    }
    //set piece 1

    void Update()
    {
        if (Inventory.Instance.ammo > 0)
        {
            if (monsterSpawned == false)
            {
                monsterSpawned = true;
                monster.SetActive(true);
            }
        }
    }

    //set piece 2
}
