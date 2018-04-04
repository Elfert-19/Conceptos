using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syringe : Weapon {

    [SerializeField]
    float maxDistance;
    [SerializeField]
    LayerMask layer;
    float shootTime;
    bool hitMiss = true;

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
                FireBullet(shotPoint);
                hitMiss = false;
            }
        }
        if (hitMiss)
        {
            FireBullet(miss);
        }
    }
}
