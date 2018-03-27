using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : UnityEngine.MonoBehaviour {
    public float totalHp;
    public float currentHp;
    public bool autoHeal;
    public float autoHealAmount;
    public float autoHealInterval;
    [SerializeField]
    bool isPrincipalLife;
    List<GameObject> onDeadGoOff;
    public bool parcialDead = false;
    List<GameObject> onParcialDeadGoOff;


    private void Start()
    {
        if(autoHeal == true)
        {
            InvokeRepeating("AutoHeal", autoHealInterval, autoHealInterval);
        }
        currentHp += totalHp;
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
            if (isPrincipalLife)
            {
                Dead();
            }
            else
            {
                ParcialDead();
            }
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
    // Controla lo que pasa cuando la vida llega a 0 y es vida principal
    public void Dead()
    {
        for (int i = 0; i < onDeadGoOff.Count; i++)
        {
            onDeadGoOff[i].SetActive(false);
        }
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
    // Controla cuando la vida llega a 0 y no es la vida princiapl
    public void ParcialDead()
    {
        parcialDead = true;
        for (int i = 0; i < onParcialDeadGoOff.Count; i++)
        {
            onParcialDeadGoOff[i].SetActive(false);
        }
    }
    // Vuelve a llenar la vida si no es el cuerpo principal y reactiva las funciones del mismo
    public void Revive()
    {
        if (isPrincipalLife == false & parcialDead == true)
        {
            parcialDead = false;
            Heal(totalHp);
            for (int i = 0; i < onParcialDeadGoOff.Count; i++)
            {
                onParcialDeadGoOff[i].SetActive(true);
            }
        }
    }
}
