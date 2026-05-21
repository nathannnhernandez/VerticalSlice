using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fog : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] private float fogDelay = 10;
    private bool coroutineRunning = false;
    void Update()
    {
        if (coroutineRunning == false)
        {
            StartCoroutine(LateMove());
        }
    }

    IEnumerator LateMove()
    {
        coroutineRunning = true;

        yield return new WaitForSeconds(fogDelay);

        coroutineRunning = false;
        transform.position = player.transform.position;
        

    }
}
