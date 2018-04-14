using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushGranade : Bullet {

    public float pushArea;
    public Collider effectArea;
    Rigidbody rb;
    public float pushForce;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        effectArea.enabled = false;
    }

    private void FixedUpdate()
    {
        BulletFly();
    }

    private void OnCollisionEnter(Collision hit)
    {
        effectArea.enabled = true;
        Invoke("DeadTime", 1);
    }

    private void OnTriggerStay(Collider hit)
    {
        if (hit.GetComponent<EnemyMovement>() != null)
        {
            hit.GetComponent<Rigidbody>().AddExplosionForce(pushForce,effectArea.transform.position, pushArea);
        }
    }

    public void BulletFly()
    {
        rb.velocity = transform.forward * speed * Time.deltaTime;
    }
}
