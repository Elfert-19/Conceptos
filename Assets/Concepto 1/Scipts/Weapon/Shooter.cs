﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    Weapon activeWapon;
    public Weapon[] availableWeapons;
    public Transform weaponAnchor;

    private void Awake()
    {
        availableWeapons = new Weapon[3];
        for (int i = 0; i < availableWeapons.Length; i++)
        {
            availableWeapons[i].gameObject.SetActive(false);
        }
        activeWapon = availableWeapons[0];
        activeWapon.gameObject.SetActive(true);
    }

    private void Update()
    {
        Shoot();
        WeaponChager();
    }

    // Controla el mouse y llama al disparo del arma
    public void Shoot()
    {
        bool primaryFire = Input.GetKey(KeyCode.Mouse0);
        bool secondaryFire = Input.GetKey(KeyCode.Mouse1);
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
            }
        }

        if (newWeapon == 2)
        {
            if (availableWeapons[1] != activeWapon)
            {
                activeWapon.gameObject.SetActive(false);
                activeWapon = availableWeapons[1];
                activeWapon.gameObject.SetActive(true);
            }
        }
        
        if(newWeapon == 3)
        {
            if(availableWeapons[2] != activeWapon)
            {
                activeWapon.gameObject.SetActive(false);
                activeWapon = availableWeapons[2];
                activeWapon.gameObject.SetActive(true);
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
}