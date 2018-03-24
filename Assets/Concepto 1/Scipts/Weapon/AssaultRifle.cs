using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : Weapon {

    [SerializeField]
    float maxDistance;
    [SerializeField]
    LayerMask layer;
    float shootTime;

    // Disparo primario del Assault Rifle
    public override void PrimaryFire()
    {
        RaycastHit hitInfo;
        if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hitInfo, maxDistance, layer))
        {
            Vector3 inpactPoint = Vector3.Normalize(hitInfo.point - firePoint.position);

            if(Physics.Raycast(firePoint.position,inpactPoint, out hitInfo, maxDistance, layer))
            {
               Vector3 shotPoint = hitInfo.point;
                RapidFire(shotPoint, hitInfo);
            }
        }
    }
    public override void FireBullet(Vector3 hitPoint)
    {
        base.FireBullet(hitPoint);
    }
    // Se encarga de disparar de manera continua y controlar la cadencia de fuego
    public void RapidFire(Vector3 position, RaycastHit hit)
    {
        float timeBetweenBullets = cadence / magazine;
        if(currentMagazine > 0)
        {
            if(Time.time - shootTime > timeBetweenBullets)
            {
                shootTime = Time.time;
                currentMagazine--;
                FireBullet(position);
                Instantiate(shotEffect, firePoint.position, firePoint.rotation, firePoint);
            }
        }
    }
}
