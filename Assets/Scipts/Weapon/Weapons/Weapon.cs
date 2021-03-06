﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public GameObject bullet;
    public AudioClip reloadSound;
    public AudioClip fireSound;
    AudioSource aSource;
    public int totalAmmo;
    public int currentAmmo;
    public int magazine;
    public int currentMagazine;
    public float cadence;
    public Transform firePoint;
    public float reloadSpeed;
    public Shooter shooter;
    public GameObject shotEffect;
    public Camera playerCamera;
    public bool automatic;
    bool boost;
    float damageMultiplier;

    protected void Awake()
    {
        aSource = GetComponent<AudioSource>();
        shooter = GetComponentInParent<Shooter>();
        if(shooter.availableWeapons[0] == null)
        {
            shooter.availableWeapons[0] = this;
        }else if (shooter.availableWeapons[1] == null)
        {
            shooter.availableWeapons[1] = this;
        }else if (shooter.availableWeapons[2] == null)
        {
            shooter.availableWeapons[2] = this;
        }
        currentAmmo += totalAmmo;
        currentMagazine += magazine;
        gameObject.SetActive(false);
    }

    // Funcion encargada de instanciar una municion en punto de disparo
    public virtual void FireBullet(Vector3 hitPoint)
    {
        GameObject shot = Instantiate(bullet);
        if (boost == true)
        {
            shot.GetComponent<Bullet>().damage = shot.GetComponent<Bullet>().damage * damageMultiplier;
        }
        shot.transform.position = hitPoint;
        if (automatic)
        {
            GameObject particle = Instantiate(shotEffect, firePoint.position, firePoint.rotation, firePoint);
            particle.GetComponent<ParticleDead>().automatic = true;
        }
        else
        {
            Instantiate(shotEffect, firePoint.position, firePoint.rotation, firePoint);
        }
        currentMagazine--;
    }

    // Funcion encargada de recargar e inpedir que se pueda disparar mientras se recargar y que la recarga no sea instantanea
    public virtual void Reload() {
        Invoke("ReloadAction", reloadSpeed);
        shooter.enabled = false;
    }

    // Controla que al recarcar el cargador se llene a medida que el pool de municiones se vasie
    protected virtual void ReloadAction()
    {
        aSource.clip = reloadSound;
        aSource.Play();
        if(currentAmmo > 0)
        {
            while(currentAmmo > 0 & currentMagazine < magazine)
            {
                currentAmmo -= 1;
                currentMagazine += 1;
            }
        }
        shooter.enabled = true;
    }

    // Funcion para aplicar algun powerUp al arma
    public virtual void PowerUp(bool active, float multiplier)
    {
        boost = true;
        damageMultiplier = multiplier;
    }

    // Disparo primario
    public virtual void PrimaryFire()
    {

    }

    // Disparo Secundario
    public virtual void SecondaryFire()
    {

    }

    // Funcion especial del arma
    public virtual void SpecialFire()
    {

    }
}
