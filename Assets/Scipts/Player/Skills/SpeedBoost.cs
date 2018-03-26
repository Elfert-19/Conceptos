using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : Skill {
    PlayerMovement pM;
    public float speedBoost;

    private void Awake()
    {
        pM = GetComponentInParent<PlayerMovement>();
    }

    public override void UseSkill()
    {
        if (used == false)
        {
            pM.speed += speedBoost;
            Invoke("SkillFinish", duration);
            used = true;
        }
    }

    public override void SkillFinish()
    {
        SkillColdown();
        pM.speed -= speedBoost;
    }
}