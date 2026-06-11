using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Monster monster;
    private bool gameEnd = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            gameEnd = true;
        }
    }

    void Update()
    {
        if (gameEnd == true)
        {
            monster = FindObjectOfType<Monster>();
            if (monster != null)
            {
                monster.currentMonsterSpeed = 0;
            }

            UIController.Instance.UpdateTextBox("Demo cleared! Deaths: " + GameController.Instance.deaths);
        }
    }
}
