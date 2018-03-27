using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperRifle : Weapon {
    [SerializeField]
    float maxDistance;
    [SerializeField]
    LayerMask layer;
    float shootTime;
    bool hitMiss = true;
    Rigidbody rb;
    public float recoil;


    private void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
    }

    // Disparo primario del Sniper Rifle
    public override void PrimaryFire()
    {
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
                rb.transform.Translate(0, 0, -recoil*Time.deltaTime);
                rb.transform.Rotate(-recoil, 0, 0);
                Invoke("ReturnPlayerPosition", 0.4f);
            }
        }
    }

    public void ReturnPlayerPosition()
    {
        rb.transform.Rotate(recoil,0,0);
    }
}
