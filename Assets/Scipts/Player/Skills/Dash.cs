using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : Skill {
    [SerializeField]
    float dashForce;
    CharacterController cc;

    private void Awake()
    {
        cc = GetComponentInParent<CharacterController>();
    }

    public override void UseSkill()
    {
        if (used == false)
        {
            cc.Move(transform.forward * dashForce * Time.deltaTime);
            timesUsed += 1;
            if (timesUsed == timesCanBeUsed)
            {
                Debug.Log("ht");
                used = true;
                Invoke("SkillFinish", cooldown);
            }
        }
     
    }

    public override void SkillFinish()
    {
        timesUsed = 0;
        used = false;
    }
}
