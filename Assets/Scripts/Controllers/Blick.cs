
using System.Collections;
using UnityEngine;

public class Blick : MonoBehaviour
{
    [SerializeField] private Camera fpsCam;
    [SerializeField] private float range = 500f;

    [Header("Gun")]
    [SerializeField] private float gunTransformMultiplier = .3f;
    private int ammoInInventory;

    [Header("Reload")]
    [SerializeField] private float reloadTime = 3f;
    private bool isReloading;
    

    [Header("Monster Slow")]
    [SerializeField] private float slowDuration = 7f;
    private float maxMonsterSpeed;
    private Monster monster;
    private Coroutine slowCoroutine;

    void Awake()
    {
        monster = FindObjectOfType<Monster>();
        if (Inventory.Instance != null)
        {
            ammoInInventory = Inventory.Instance.ammo;
        }
    }

    void Start()
    {
        UIController.Instance.UpdateAmmoCount(ammoInInventory);
        maxMonsterSpeed = monster.monsterSpeed;
    }

    void Update()
    {
        ammoInInventory = Inventory.Instance.ammo;
        /*if (isReloading) return;

        if (Input.GetKeyDown(KeyCode.R))
            StartCoroutine(Reload());*/

        if (Input.GetKey(KeyCode.Mouse1) && Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (ammoInInventory > 0)
                Shoot();
        }
        UIController.Instance.UpdateAmmoCount(ammoInInventory);
    }

    void Shoot()
    {
        Inventory.Instance.ammo -= 1;
        StartCoroutine(Recoil());

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out RaycastHit hit, range))
        {
            Debug.Log(hit.transform.name);

            if (hit.transform.TryGetComponent(out Monster hitMonster))
            {
                ApplySlow();
            }

        }

       /* if (ammoInInventory <= 0)
            StartCoroutine(Reload());*/
    }

    void ApplySlow()
    {
        monster.monsterSpeed = Mathf.Max(monster.monsterSpeed * 0.5f, 2f);

        if (slowCoroutine != null)
            StopCoroutine(slowCoroutine);

        slowCoroutine = StartCoroutine(RestoreMonsterSpeed());
    }

    IEnumerator RestoreMonsterSpeed()
    {
        yield return new WaitForSeconds(slowDuration);
        monster.monsterSpeed = maxMonsterSpeed;
    }
    /*

    IEnumerator Reload()
    {
        StartCoroutine(ReloadAnimation());
        isReloading = true;

        yield return new WaitForSeconds(reloadTime);

        transform.position += Vector3.down;
        for (int i = 0; i < ammoInInventory; i++)
        {
            
        }
        UIController.Instance.UpdateAmmoCount(ammoInInventory);

        transform.position += Vector3.up;

        isReloading = false;
    } */
    
    IEnumerator Recoil()
    {
        transform.position += Vector3.up * gunTransformMultiplier;
        transform.position -= Vector3.back * gunTransformMultiplier;

        yield return new WaitForSeconds(0.1f);

        transform.position -= Vector3.up * gunTransformMultiplier;
        transform.position += Vector3.back * gunTransformMultiplier;
   }

   IEnumerator ReloadAnimation()
    {
        transform.position -= Vector3.up * gunTransformMultiplier * 2;

        yield return new WaitForSeconds(reloadTime);

        transform.position += Vector3.up * gunTransformMultiplier * 2;
    }

}/* using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Blick : MonoBehaviour
{
    [SerializeField] public float damage = 1f;
    [SerializeField] private Camera fpsCam;
    [SerializeField] private GameObject onHitRender;
    [SerializeField] private float reloadTime = 3f;
    Monster monster;
    private float maxMonsterSpeed = 10f;
    public int ammo = 6;
    public float range = 500f;
    private float timeRemaining = 7f;
    private bool timerRunning = false;
    private bool reloadTimerRunning = false;
    void Awake()
    {
        monster = FindObjectOfType<Monster>();
        maxMonsterSpeed = monster.monsterSpeed;
    }

    void Start()
    {
        UIController.Instance.UpdateAmmoCount(ammo);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            transform.position += Vector3.down * 0.5f;
            reloadTimerRunning = true;
        }
        if (reloadTimerRunning)
        {
            reloadTime -= Time.deltaTime;
            if (reloadTime <= 0)
            {
                reloadTimerRunning = false;
                Reload();
                reloadTime = 3f;
            }    
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && ammo > 0)
            {
                ShootThatBih();
            }
        }

        if (timerRunning)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                monster.monsterSpeed = maxMonsterSpeed;
                timerRunning = false;
                timeRemaining = 7f;
            }
        }
    }

    void ShootThatBih()
    {
        RaycastHit hit;
        ammo -= 1;
        UIController.Instance.UpdateAmmoCount(ammo);

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Monster hitMonster = hit.transform.GetComponent<Monster>();

            if (hitMonster != null)
            {
                timeRemaining = 7f;
                Debug.Log(timeRemaining);
                if (monster.monsterSpeed > 2)
                {
                    monster.monsterSpeed *= 0.5f;
                    StartTimerForMonsterRejuvination(monster.monsterSpeed);
                } 
            }
            Instantiate(onHitRender, hit.transform);
        }
    }
    void StartTimerForMonsterRejuvination(float currentSpeed)
    {
        if (currentSpeed <= maxMonsterSpeed)
        {
            timerRunning = true;
        }
    }
    void Reload()
    {
        transform.position += Vector3.up * 0.5f;
        ammo = 6;
        UIController.Instance.UpdateAmmoCount(ammo);
    }
}
*/
