using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : UnityEngine.MonoBehaviour {
    public float cooldown;
    public bool used;
    public float timeSinceUse;
    public float duration;
    public int timesCanBeUsed;
    public int timesUsed;

    // Aplica efecto de la abilidad
    public virtual void UseSkill()
    {

    }
    // Aplica el enfriamento del a abilidad
    public virtual void SkillColdown()
    {
        if(used == true)
        {
            if(timeSinceUse > cooldown)
            {
                used = false;
            }
        }
    }
    // Lo que sucede cuando cuando la abilidad termina
    public virtual void SkillFinish()
    {

    }
}
