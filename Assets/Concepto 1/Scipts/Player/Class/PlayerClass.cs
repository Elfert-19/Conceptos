using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour {
    Life life;
    Armor armor;
    [SerializeField]
    Weapon[] classWeapons;
    Shooter shooter;
    [SerializeField]
    float hp;
    [SerializeField]
    float classArmor;
    [SerializeField]
    float speed;
    [SerializeField]
    float jump;
    [SerializeField]
    Skill[] skill;
    Skill skillQ;
    Skill skillE;
    PlayerMovement playerMovement;
    
    // Reparte los valores corriespondiente de la clase a cada componente
    private void Awake()
    {
        life = GetComponent<Life>();
        armor = GetComponent<Armor>();
        shooter = GetComponent<Shooter>();
        playerMovement = GetComponent<PlayerMovement>();
        foreach(Weapon weapon in classWeapons)
        {
            Instantiate(weapon, shooter.weaponAnchor.position, shooter.weaponAnchor.rotation,shooter.weaponAnchor);
        }
        skillE = skill[0];
        skillQ = skill[1];
    }
    // Reparte los valores corriespondiente de la clase a cada componente
    private void Start()
    {
        life.totalHp = hp;
        armor.baseArmor = classArmor;
        playerMovement.speed = speed;
        playerMovement.jump = jump;
    }

    private void Update()
    {
        SkillFire();
    }
    // Dispara las abilidades de la clase
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
