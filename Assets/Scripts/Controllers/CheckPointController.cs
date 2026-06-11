using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            GameController.Instance.RespawnPos = gameObject.transform.position;
            Debug.Log(GameController.Instance.RespawnPos);
            
            Destroy(gameObject);
        }
    }
}
