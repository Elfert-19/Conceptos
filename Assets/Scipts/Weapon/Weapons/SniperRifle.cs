﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperRifle : Weapon {
    [SerializeField]
    float maxDistance;
    [SerializeField]
    LayerMask layer;
    float shootTime;
    bool hitMiss = true;
    CharacterController cc;
    PlayerMovement pm;
    public float recoil;
    Camera Scope;


    private void Start()
    {
        cc = GetComponentInParent<CharacterController>();
        pm = GetComponentInParent<PlayerMovement>();
        pm.canMove = true;
        Scope = GetComponentInChildren<Camera>();
    }

    // Disparo primario del Sniper Rifle
    public override void PrimaryFire()
    {
        hitMiss = true;
        Vector3 miss = new Vector3(0, -200, 0);
        RaycastHit hitInfo;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hitInfo, maxDistance, layer))
        {
            Vector3 inpactPoint = Vector3.Normalize(hitInfo.point - firePoint.position);

            if (Physics.Raycast(firePoint.position, inpactPoint, out hitInfo, maxDistance, layer))
            {
                Vector3 shotPoint = hitInfo.point;
                SniperFire(shotPoint);
                hitMiss = false;
            }
        }
        if (hitMiss)
        {
            SniperFire(miss);
        }
    }
    // Accion secundaria del Sniper Riffle
    public override void SecondaryFire()
    {
        if(Scope.enabled == false)
        {
            Scope.enabled = true;
        }
        else
        {
            Scope.enabled = false;
        }
    }

    // Aplica el efecto de disparo del Sniper Rifle
    public void SniperFire(Vector3 hitPoint)
    {
        float timeBetweenBullets = cadence / magazine;
        if (currentMagazine > 0)
        {
            if (Time.time - shootTime > timeBetweenBullets)
            {
                shootTime = Time.time;
                FireBullet(hitPoint);
                cc.transform.Translate(0, 0, -recoil*Time.deltaTime);
                playerCamera.transform.Rotate(-recoil/2, 0, 0);
                pm.canMove = false;
                Invoke("ReturnPlayerPosition", 0.4f);
            }
        }
    }
    // Vuelve a acomodar el jugar en la posicion original
    public void ReturnPlayerPosition()
    {
        pm.canMove = true;
        playerCamera.transform.Rotate(recoil,0,0);
    }
}
