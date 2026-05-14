using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class HealthManager : MonoBehaviour
{
    [SerializeField] GameObject monster;
    [SerializeField] int maxHP = 3;
    [SerializeField] float iFramesLength = 7f;
    private bool invulnerable = false;
    public int hp;
    // Start is called before the first frame update
    void Start()
    {
        hp = maxHP;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == monster && invulnerable == false)
        {
            StartCoroutine(IFrames(iFramesLength));
            hp -= 1;
            Debug.Log(hp);
        }
    }
    IEnumerator IFrames(float delay)
    {
        invulnerable = true;
        
        yield return new WaitForSeconds(delay);

        invulnerable = false;
    }
}
