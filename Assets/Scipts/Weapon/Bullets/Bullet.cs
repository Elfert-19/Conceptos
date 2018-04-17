using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed;
    public float damage;
    Armor armor;
    public GameObject bulletEfect;

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
        Destroy(gameObject);
    }

    public void OnDestroy()
    {
        CancelInvoke();
    }
}
