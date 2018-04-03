﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : UnityEngine.MonoBehaviour {
    public float speed;
    public float damage;
    Armor armor;
    public UnityEngine.GameObject bulletEfect;
    public bool powerUpON;
    public bool specialEffectOn;

    public virtual void ApplyDamage(Collider hit)
    {
        if (hit.GetComponent<Armor>() != null)
        {
            hit.GetComponent<Armor>().ApplyArmor(damage);
            Instantiate(bulletEfect, gameObject.transform.position, gameObject.transform.rotation);
            DeadTime();
        }

        Instantiate(bulletEfect, gameObject.transform.position, gameObject.transform.rotation);
        DeadTime();
    }
    // Destruye la bala
    public void DeadTime()
    {
        Destroy(gameObject.gameObject);
    }
    // Movimiento de la bala
    public virtual void BulletFly()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }
    // Aplica alguna particularidad del disparo;
    public virtual void SpecialEffect()
    {

    }
    // Aplica algun efecto momentaneo de las blas
    public virtual void PowerUp()
    {

    }

    public void OnDestroy()
    {
        CancelInvoke();
    }
}
