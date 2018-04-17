using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : UnityEngine.MonoBehaviour {
    public Weapon activeWapon;
    public Weapon[] availableWeapons;
    public Transform weaponAnchor;
    Camera playerCamera;

    private void Awake()
    {
        availableWeapons = new Weapon[3];
    }

    private void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
        activeWapon = availableWeapons[0];
        activeWapon.gameObject.SetActive(true);
        activeWapon.playerCamera = playerCamera;
    }

    private void Update()
    {
        Shoot();
        Reload();
        WeaponChager();
    }

    // Controla el mouse y llama al disparo del arma
    public void Shoot()
    {

        bool primaryFire;
        if (activeWapon.automatic)
        {
            primaryFire = Input.GetKey(KeyCode.Mouse0);
        }
        else
        {
            primaryFire = Input.GetKeyDown(KeyCode.Mouse0);
        }
        bool secondaryFire = Input.GetKeyDown(KeyCode.Mouse1);
        bool specialFire = Input.GetKeyDown(KeyCode.Mouse2);

        if (primaryFire)
        {
            activeWapon.PrimaryFire();
        }

        if (secondaryFire)
        {
            activeWapon.SecondaryFire();
        }
        if (specialFire)
        {
            activeWapon.SpecialFire();
        }
    }

    // Funcion que se encarga de cambiar el arma
    public void SwitchWeapon(int newWeapon)
    {
        if(newWeapon == 1)
        {
            if(availableWeapons[0] != activeWapon)
            {
                activeWapon.gameObject.SetActive(false);
                activeWapon = availableWeapons[0];
                activeWapon.gameObject.SetActive(true);
                activeWapon.playerCamera = playerCamera;
            }
        }

        if (newWeapon == 2)
        {
            if (availableWeapons[1] != activeWapon)
            {
                activeWapon.gameObject.SetActive(false);
                activeWapon = availableWeapons[1];
                activeWapon.gameObject.SetActive(true);
                activeWapon.playerCamera = playerCamera;
            }
        }
        
        if(newWeapon == 3)
        {
            if(availableWeapons[2] != activeWapon)
            {
                activeWapon.gameObject.SetActive(false);
                activeWapon = availableWeapons[2];
                activeWapon.gameObject.SetActive(true);
                activeWapon.playerCamera = playerCamera;
            }
        }
    }

    // Controla la peticion de cambio de armas del personaje
    public void WeaponChager()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchWeapon(3);
        }
    }
    // Llama a la funcion recarga del arma
    public void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            activeWapon.Reload();
        }
    }
}
