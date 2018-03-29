using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootgunBullet : Bullet {
    Rigidbody hitRb;
    public float impactForce;
    float liveTime;
    [SerializeField]
    float travelTime;

    private void Update()
    {
        BulletFly();
    }

    private void Awake()
    {
        Invoke("DeadTime", travelTime);
    }

    private void OnCollisionStay(Collision hit)
    {
        if (hit.collider.GetComponent<Rigidbody>() == true)
        {
            hitRb = hit.collider.GetComponent<Rigidbody>();
            hitRb.AddForce(gameObject.transform.forward * impactForce, ForceMode.Impulse);
        }
        ApplyDamage(hit.collider);
    }
    // Destruye la bala
    private void DeadTime()
    {
        Destroy(gameObject.gameObject);
    }
}
