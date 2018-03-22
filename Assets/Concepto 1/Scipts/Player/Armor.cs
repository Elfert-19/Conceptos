using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour {
    public float baseArmor;
    public float totalArmor;
    Life hp;

    // Aplica un efecto de reduccion de daño en realacion a la armadura y luego se la pasa a la funcion daño del script Life
    public void ApplyArmor(float damage)
    {
        float filterDamage = (baseArmor*100) / (baseArmor + totalArmor);
        float totalDamage = damage - ((damage / 100) * filterDamage);
        hp.Damage(totalDamage);
    }
}
