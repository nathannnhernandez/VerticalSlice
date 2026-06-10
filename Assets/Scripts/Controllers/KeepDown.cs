using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepDown : MonoBehaviour
{
    [SerializeField] private GameObject leon;
    [SerializeField] private GameObject xBot;

    // Update is called once per frame
    void Update()
    {
        leon.transform.position = new Vector3(leon.transform.position.x, 0.5f, leon.transform.position.z);        
        xBot.transform.position = new Vector3(xBot.transform.position.x, 0.5f, xBot.transform.position.z);

    }
}
