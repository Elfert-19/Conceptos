﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyringeBullet : Bullet {
    Life life;
    public int hpRecoveryAmount;

    private void OnCollisionEnter(Collision hit)
    {
        if (hit.collider.GetComponent<Life>())
        {
            life = hit.collider.GetComponent<Life>();
            life.currentHp += hpRecoveryAmount;
        }
        Invoke("DeadTime", 1);
    }
}