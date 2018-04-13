using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowBullet : Bullet {

    public float speedDivisor;
    public float duration;
    Rigidbody rb;
    public Collider effectArea;

    private void Awake()
    {
        effectArea.enabled = false;
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        effectArea.enabled = true;
        Invoke("DeadTime", duration);
        rb.useGravity = false;
        transform.rotation = new Quaternion(0, 0, 0, 0);
        speed = 0;
    }

    private void FixedUpdate()
    {
            BulletFly();
    }

    private void OnTriggerStay(Collider hit)
    {
        if (hit.GetComponent<EnemyMovement>())
        {
            EnemyMovement enemy = hit.GetComponent<EnemyMovement>();
            enemy.speed = enemy.speed / speedDivisor;
        }
    }

    private void OnTriggerExit(Collider hit)
    {
        if (hit.GetComponent<EnemyMovement>())
        {
            EnemyMovement enemy = hit.GetComponent<EnemyMovement>();
            enemy.speed = enemy.speed * speedDivisor;
        }
    }

    public void BulletFly()
    {
        rb.velocity = transform.forward * speed * Time.deltaTime;
    }
}
