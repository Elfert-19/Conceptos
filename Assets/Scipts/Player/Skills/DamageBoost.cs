using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoost : Skill {
    Shooter shooter;
    PlayerMovement pm;
    public float damageMultiplier;

    private void Awake()
    {
        shooter = GetComponentInParent<Shooter>();
        pm = GetComponentInParent<PlayerMovement>();
    }

    public override void UseSkill()
    {
        if(!used)
        { 
            shooter.activeWapon.PowerUp(true, damageMultiplier);
            pm.stunt = true;
            used = true;
        }
        else
        {
            shooter.activeWapon.PowerUp(false, 1);
            pm.stunt = false;
            used = false;
        }
    }
}
