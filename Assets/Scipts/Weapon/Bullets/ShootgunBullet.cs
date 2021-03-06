﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootgunBullet : Bullet {
    Rigidbody hitRb;
    public float impactForce;
    float liveTime;
    [SerializeField]
    float travelTime;

    private void Awake()
    {
        Invoke("DeadTime", travelTime);
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
