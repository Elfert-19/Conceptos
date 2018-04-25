using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleAtack : MonoBehaviour {

    public float damage;

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.GetComponent<Armor>())
        {
            hit.GetComponent<Armor>().ApplyArmor(damage);
        }
    }
}
