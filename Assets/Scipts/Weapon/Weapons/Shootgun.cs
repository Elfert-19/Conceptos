using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootgun : Weapon {
    public float spread;
    float shootTime;
    public int pellets;
    int pelletFired;

    public override void PrimaryFire()
    {
        ShootGunFire();
    }
    // Disparo primario de la escopeta
    public void ShootGunFire()
    {
        float timeBetweenBullets = cadence / magazine;

        if (currentMagazine > 0)
        {
            if (Time.time - shootTime > timeBetweenBullets)
            {
                shootTime = Time.time;
                for (int i = 0; i < pellets; i++)
                {
                    Vector3 bulletAngle = Vector3.zero;
                    bulletAngle.x = Random.Range(-spread, spread);
                    bulletAngle.y = Random.Range(-spread, spread);
                    FireBullet(bulletAngle);
                }
            }
        }
    }
    // Rota la bala instaciada para dar el efecto de spread al disparo
    public override void FireBullet(Vector3 bulletRotation)
    {
        GameObject shot = Instantiate(bullet, firePoint.position,firePoint.rotation);
        shot.transform.Rotate(bulletRotation.x, bulletRotation.y, 0);
        if (automatic)
        {
            GameObject particle = Instantiate(shotEffect, firePoint.position, firePoint.rotation, firePoint);
            particle.GetComponent<ParticleDead>().automatic = true;
        }
        else
        {
            Instantiate(shotEffect, firePoint.position, firePoint.rotation, firePoint);
        }
        if (pelletFired == pellets)
        {
            currentMagazine--;
            pelletFired = 0;
        }
    }
}
