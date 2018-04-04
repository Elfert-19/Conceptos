using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : UnityEngine.MonoBehaviour {
    public float baseArmor;
    public float extraArmor;
    Life hp;

    private void Awake()
    {
        hp = GetComponent<Life>();
    }

    // Aplica un efecto de reduccion de daño en realacion a la armadura y luego se la pasa a la funcion daño del script Life
    public void ApplyArmor(float damage)
    {
        float filterDamage = (damage/100)*(baseArmor+extraArmor);
        int totalDamage = Mathf.RoundToInt(damage - filterDamage);
        hp.Damage(totalDamage);
    }
}
