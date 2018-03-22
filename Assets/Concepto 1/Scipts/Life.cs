using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {
    public float totalHp;
    public float currentHp;
    public bool autoHeal;
    public float autoHealAmount;
    public float autoHealInterval;

    private void Awake()
    {
        if(autoHeal == true)
        {
            InvokeRepeating("AutoHeal", autoHealInterval, autoHealInterval);
        }
    }

    // Se le pasa un daño y se lo resta a la vida, luego llama a la funcion de control
    public void Damage(float dm)
    {
        currentHp -= dm;
        Status();
    }

    // Controla que la vida no sea mayor del total de vida
    public void Status()
    {
        if (currentHp < 0)
        {
            Dead();
        }
        if(currentHp > totalHp)
        {
            currentHp = totalHp;
        }
    }
    // Aplica una curacion y llama a la funcion de control
    public void Heal(float heal)
    {
        currentHp += heal;
        Status();
    }
    // Controla lo que pasa cuando la vida llega a 0
    public void Dead()
    {

    }
    // Controla que el la auto curacion siga estando activa y aplica una curacion
    public void AutoHeal()
    {
        if (autoHeal == true)
        {
            Heal(autoHealAmount);
            Status();
        }
        if(autoHeal == false)
        {
            Heal(autoHealAmount);
            Status();
            CancelInvoke();
        }
    }
}
