using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : Skill {
    PlayerMovement pm;

    private void Awake()
    {
        pm = GetComponent<PlayerMovement>();
    }

    public override void UseSkill()
    {
        if (used == false)
        {
            pm.groundMode = false;
            Invoke("SkillFinish", duration);
            used = true;
        }
    }

    public override void SkillFinish()
    {
        SkillColdown();
        pm.groundMode = true;
    }
}
