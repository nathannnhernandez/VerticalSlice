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
    public Vector3 RespawnPos;
    public int deaths = 0;

    [Header("General")]
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

    [Header("Set Piece 1")]
    [SerializeField] private GameObject fence1;
    [SerializeField] private GameObject checkPoint1;

    private bool monsterSpawned;
    void Start()
    {
        currentGameState = GameState.gameState1;

        RespawnPos = player.transform.position;

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

        if (setPiece2Trigger.activeInHierarchy == false && currentGameState == GameState.gameState2)
        {
            if (monsterSpawned == false)
            {
                monster.transform.position = new Vector3(8f, 4.988858f, -80f);
                monsterSpawned = true;
                monster.SetActive(true);

                fence1.SetActive(true);
                fence2.SetActive(false);
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
            monster.SetActive(false);
            monsterSpawned = false;

            audioSource.Play();

            currentGameState = GameState.gameState3;
        }
        else if (checkPoint3 == null && currentGameState == GameState.gameState2)
        {
        }

        if (currentGameState == GameState.gameState3 && finalSequenceTrigger.activeInHierarchy == false)
        {
            if (monsterSpawned == false)
            {
                monster.transform.position = new Vector3(-154.3974f, 4.988858f, -52f);
                monster.SetActive(true);
                monsterSpawned = true;

                audioSource.Play();

            }

            
        }
        if (currentGameState == GameState.gameState3 && Inventory.Instance.keys > 0)
        {
            fence3.SetActive(false);
        }
    
    }
    //set piece 2
    [Header("Set Piece 2")]
    [SerializeField] private GameObject checkPoint2;
    [SerializeField] private GameObject setPiece2Trigger;
    [SerializeField] private GameObject fence2;

    //set piece 3
    [Header("Set Piece 3")]
    [SerializeField] private GameObject checkPoint3;
    [SerializeField] private GameObject fence3;
    [SerializeField] private GameObject finalSequenceTrigger;
}