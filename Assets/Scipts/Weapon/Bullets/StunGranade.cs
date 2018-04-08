using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunGranade : Bullet {
    
    public float stunDuration;
    public Collider effectArea;
    Rigidbody rb;

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

    private void OnTriggerEnter(Collider hit)
    {
        if(hit.GetComponent<EnemyMovement>() != null)
        {
            hit.GetComponent<EnemyMovement>().Stun(stunDuration);
        }
    }

    public void BulletFly()
    {
        rb.velocity = transform.forward * speed * Time.deltaTime;
    }
}
