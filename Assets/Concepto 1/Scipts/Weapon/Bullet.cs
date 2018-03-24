using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : UnityEngine.MonoBehaviour {
    public float speed;
    public float damage;
    Armor armor;
    public GameObject bulletEfect;
    public bool powerUpON;
    public bool specialEffectOn;

    public virtual void ApplyDamage(Collider hit)
    {
        if (hit.GetComponent<Armor>() != null)
        {
            armor = hit.GetComponent<Armor>();
            armor.ApplyArmor(damage);
            Instantiate(bulletEfect, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
            Instantiate(bulletEfect, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject.gameObject);
    }
    // Movimiento de la bala
    public virtual void BulletFly()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
    // Aplica alguna particularidad del disparo;
    public virtual void SpecialEffect()
    {

    }
    // Aplica algun efecto momentaneo de las blas
    public virtual void PowerUp()
    {

    }
}
