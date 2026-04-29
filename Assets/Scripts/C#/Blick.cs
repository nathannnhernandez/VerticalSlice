using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blick : MonoBehaviour
{
    [SerializeField] public float damage = 1f;
    [SerializeField] private Camera fpsCam;
    [SerializeField] private GameObject onHitRender;
    public int ammo = 10;
    public float range = 500f;

    void Start()
    {
        UIController.Instance.UpdateAmmoCount(ammo);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            ammo = 10;
            UIController.Instance.UpdateAmmoCount(ammo);
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && ammo > 0)
            {
                ShootThatBih();
            }
        }

    }

    void ShootThatBih()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            ammo -= 1;
            Debug.Log(hit.transform.name);
            Instantiate(onHitRender, hit.transform);
            UIController.Instance.UpdateAmmoCount(ammo);
        }
    }
}
