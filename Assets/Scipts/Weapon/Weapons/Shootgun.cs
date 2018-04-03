using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootgun : Weapon {
    public float spread;
    public float circularSpread;
    float shootTime;
    public int pellets;
    int pelletFired;
    public float maxDistance;
    public LayerMask layer;
    Collider[] hitObjects;
    bool hitMiss = true;
    Vector3 shootSpread;


    public override void PrimaryFire()
    {
        hitMiss = true;
        for (int i = 0; i < pellets; i++)
        {
            ShootgunRay();
        }
    }
    // Los chequeo de disparo por rayo de la escopeta
    public void ShootgunRay()
    {
        Vector3 miss = new Vector3(0, -200, 0);
        Vector3 hitDirecction = playerCamera.transform.forward;
        shootSpread += playerCamera.transform.up * Random.Range(-spread, spread);
        shootSpread += playerCamera.transform.right * Random.Range(-spread, spread);
        hitDirecction += shootSpread.normalized * Random.Range(-circularSpread, circularSpread);
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, hitDirecction, out hit, maxDistance, layer))
        {
            Vector3 impactPoint = Vector3.Normalize(new Vector3(hit.point.x + hitDirecction.x, hit.point.y + hitDirecction.y, hit.point.z) - firePoint.position);
            if (Physics.Raycast(firePoint.position, impactPoint, out hit, maxDistance, layer))
            {
                impactPoint = hit.point;
                ShootGunFire(impactPoint);
                hitMiss = false;
            }
        }
        else
        {
            if (hitMiss == true)
            {
                ShootGunFire(miss);
            }
        }
    }
    // Disparo primario de la escopeta
    public void ShootGunFire(Vector3 hitPoint)
    {
        if (currentMagazine > 0)
        {
            FireBullet(hitPoint);
            pelletFired += 1;
            Debug.DrawLine(firePoint.position, hitPoint, Color.red);
            if (pelletFired >= pellets)
            {
                 pelletFired = 0;
                currentMagazine -= 1;
            }
        }
    }

    public override void FireBullet(Vector3 hitPoint)
    {
        UnityEngine.GameObject shot = Instantiate(bullet);
        shot.transform.position = hitPoint;
        if (automatic)
        {
            UnityEngine.GameObject particle = Instantiate(shotEffect, firePoint.position, firePoint.rotation, firePoint);
            particle.GetComponent<ParticleDead>().automatic = true;
        }
        else
        {
            Instantiate(shotEffect, firePoint.position, firePoint.rotation, firePoint);
        }
    }
}
