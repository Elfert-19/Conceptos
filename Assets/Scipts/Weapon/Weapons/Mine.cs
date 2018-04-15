using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour {

    public float speed;
    public float explosionRadio;
    public float explosionForce;
    public float explosionDamage;
    public LayerMask layer;
    Collider[] affected;
    public float timeLived;
    public MineLauncher mineLauncher;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        affected = new Collider[20];
    }

    private void Update()
    {
        BulletFly();
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.tag.Equals("Stage"))
        {
            rb.useGravity = false;
            transform.rotation = new Quaternion(0, 0, 0, 0);
            speed = 0;
        }
        if (hit.GetComponent<PlayerMovement>() == false & hit.tag.Equals("Enemy"))
        {
            Explosion();
        }
    }

    public void Explosion()
    {
        Physics.OverlapSphereNonAlloc(gameObject.transform.position, explosionRadio, affected, layer);
        if (affected[0] != null)
        {
            for (int i = 0; i < affected.Length; i++)
            {
                if (affected[i] != null & affected[i].GetComponent<Armor>() != null)
                {
                    affected[i].GetComponent<Armor>().ApplyArmor(explosionDamage);
                    affected[i].GetComponent<Rigidbody>().AddExplosionForce(explosionForce, gameObject.transform.position, explosionRadio);
                    Destroy(gameObject);
                }
                Destroy(gameObject);
            }
        }
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        mineLauncher.MineRemoved(gameObject);
    }

    public void BulletFly()
    {
        rb.velocity = transform.forward * speed * Time.deltaTime;
    }
}
