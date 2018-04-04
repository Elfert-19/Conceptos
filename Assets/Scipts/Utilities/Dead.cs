using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour {
    Life life;

    public virtual void Awake()
    {
        life = GetComponent<Life>();
    }

    public virtual void ControlDead()
    {
        if (life.parcialDead)
        {
            ParcialDead();
        }
        if (life.dead)
        {
            FinalDead();
        }
    }


    public virtual void ParcialDead()
    {

    }
    
    public virtual void FinalDead()
    {

    }
}
