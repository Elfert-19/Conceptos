using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBullet : Bullet {

    private void OnCollisionStay(Collision hit)
    {
        ApplyDamage(hit.collider);
        Invoke("DeadTime", 1);
    }
}
