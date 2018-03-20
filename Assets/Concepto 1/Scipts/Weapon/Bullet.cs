using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed;
    public float damage;
    Armor armor;
    GameObject bulletEfect;

    public virtual void OnTriggerEnter(Collider hit)
    {
        
        if(hit.GetComponent<Armor>() != null)
        {
            armor = hit.GetComponent<Armor>();
            Destroy(gameObject);
        }
        GameObject effect = Instantiate(bulletEfect,gameObject.transform.position,gameObject.transform.rotation);
        Destroy(gameObject);
    }

    public virtual void BulletFly()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    public virtual void SpecialEffect()
    {

    }

    public virtual void PowerUp()
    {

    }
}
