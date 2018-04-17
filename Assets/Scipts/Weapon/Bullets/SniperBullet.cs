using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperBullet : Bullet {
    Rigidbody hitRb;
    public float impactForce;

    private void Start()
    {
        Invoke("DeadTime", 1);
    }

    private void OnCollisionStay(Collision hit)
    {
        if (hit.collider.GetComponent<Rigidbody>() == true)
        {
            hitRb = hit.collider.GetComponent<Rigidbody>();
            Vector3 direction = Vector3.Normalize(transform.position - hitRb.position);
            hitRb.AddForce(-direction * impactForce);
        }
        ApplyDamage(hit.collider);
    }
}
