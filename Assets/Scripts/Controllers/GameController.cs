using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //singleton logic
    public static GameController Instance { get; private set; }
    private enum GameState
    {
        gameState1,
        gameState2,
        gameState3,
        gameState4
    }
    private GameState currentGameState;

    [SerializeField] private GameObject monster;
    [SerializeField] private GameObject player;
    [SerializeField] private AudioSource audioSource;
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

    [SerializeField] private GameObject fence1;
    [SerializeField] private GameObject checkPoint1;

    private bool monsterSpawned;
    void Start()
    {
        currentGameState = GameState.gameState1;

        monsterSpawned = false;
        monster.SetActive(false);

    }
    //set piece 1
    [SerializeField] private AudioClip firstAudioClip;

    void Update()
    {
        //pickup set pieces
        if (Inventory.Instance.ammo > 0 && currentGameState == GameState.gameState1)
        {

            fence1.SetActive(false);
            if (monsterSpawned == false)
            {
                monsterSpawned = true;
                monster.SetActive(true);

                audioSource.clip = firstAudioClip;
                audioSource.Play();
            }
        }

        //checkpoints
        if (checkPoint1 == null && currentGameState == GameState.gameState1)
        {
            monster.SetActive(false);
            monsterSpawned = false;

            audioSource.Play();

            currentGameState = GameState.gameState2;
        }
        else if (checkPoint2 == null && currentGameState == GameState.gameState2)
        {
            
        }
    
    }
    //set piece 2
    [SerializeField] private GameObject checkPoint2;
}