using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadeLauncher : Weapon {
    public List<GameObject> bulletsAvalides;
    int bulletType;

    public override void PrimaryFire()
    {
        if(currentMagazine > 0)
        {
            FireBullet(Vector3.zero);
        }
    }

    public override void SecondaryFire()
    {
        bulletType += 1;
        if(bulletType > bulletsAvalides.Count)
        {
            bulletType = 0;
        }
    }

    public override void FireBullet(Vector3 hitPoint)
    {
        Instantiate(bulletsAvalides[bulletType], firePoint.position, firePoint.rotation);
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
}
