using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour {
    Life life;
    Armor armor;
    Weapon[] classWeapons;
    Shooter shooter;
    [SerializeField]
    float hp;
    [SerializeField]
    float classArmor;
    GameObject[] skill;
    Skill skillQ;
    Skill skillE;
    
    // Reparte los valores corriespondiente de la clase a cada componente
    private void Awake()
    {
        life = GetComponent<Life>();
        armor = GetComponent<Armor>();
        shooter = GetComponent<Shooter>();
        shooter.availableWeapons = classWeapons;
        foreach(Weapon weapon in classWeapons)
        {
            Instantiate(weapon, shooter.weaponAnchor.position, shooter.weaponAnchor.rotation,shooter.weaponAnchor);
        }
        skillE = skill[1].GetComponent<Skill>();
        skillQ = skill[2].GetComponent<Skill>();
    }
    // Reparte los valores corriespondiente de la clase a cada componente
    private void Start()
    {
        life.totalHp = hp;
        armor.baseArmor = classArmor;
    }

    private void Update()
    {
        SkillFire();
    }

    public void SkillFire()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            skillQ.UseSkill();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            skillE.UseSkill();
        }
    }
}
