using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed;
    public float damage;
    Armor armor;
    public GameObject bulletEfect;

    public virtual void OnTriggerEnter(Collider hit)
    {
        
        if(hit.GetComponent<Armor>() != null)
        {
            armor = hit.GetComponent<Armor>();
            armor.ApplyArmor(damage);
            Instantiate(bulletEfect, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
        Instantiate(bulletEfect,gameObject.transform.position,gameObject.transform.rotation);
        Destroy(gameObject);
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

    public virtual void PowerUp()
    {

    }
}
