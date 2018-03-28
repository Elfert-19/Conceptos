using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperBullet : Bullet {
    Rigidbody hitRb;
    public float impactForce;
    
    private void OnCollisionStay(Collision hit)
    {
        if (hit.collider.GetComponent<Rigidbody>() == true)
        {
            hitRb = hit.collider.GetComponent<Rigidbody>();
            hitRb.AddForce(gameObject.transform.forward * impactForce, ForceMode.Impulse);
        }
        ApplyDamage(hit.collider);
    }
}
