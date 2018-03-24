using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRiffleBullet : Bullet {

    private void OnCollisionStay(Collision hit)
    {
        ApplyDamage(hit.collider);
        Debug.Log("hit");
    }
}
