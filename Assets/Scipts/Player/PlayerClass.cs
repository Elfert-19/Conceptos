using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour {
    public enum Jobs {Asault, Sniper, Support, Engineer};
    public Jobs playerJob;
    public Class_Data data;
    Life life;
    Armor armor;
    Weapon[] classWeapons;
    Shooter shooter;
    float hp;
    float classArmor;
    float speed;
    float jump;
    Skill[] skill;
    Skill skillQ;
    Skill skillE;
    PlayerMovement playerMovement;
    public Camera playerCamera;
    
    // Reparte los valores corriespondiente de la clase a cada componente
    private void Awake()
    {
        life = GetComponent<Life>();
        armor = GetComponent<Armor>();
        shooter = GetComponent<Shooter>();
        playerMovement = GetComponent<PlayerMovement>();
        playerCamera = GetComponentInChildren<Camera>();
        PlayerJob();
        foreach(Weapon weapon in classWeapons)
        {
            Instantiate(weapon, shooter.weaponAnchor.position, shooter.weaponAnchor.rotation,shooter.weaponAnchor);
        }
        skillQ = Instantiate(skill[0], gameObject.transform).GetComponentInChildren<Skill>();
        skillE = Instantiate(skill[1], gameObject.transform).GetComponentInChildren<Skill>();
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

    // Recibe y asgigna las propiedades, armas y abilidades de de la clase seleccionada
    public void PlayerJob()
    {
        if(playerJob == Jobs.Asault)
        {
            life.totalHp = data.assaultHp;
            armor.baseArmor = data.assaultArmor;
            playerMovement.speed = data.assaultSpeed;
            playerMovement.jump = data.assaultJump;
            classWeapons = data.assaultWeapons;
            skill = data.assaultSkills;

        }
        if (playerJob == Jobs.Sniper)
        {
            life.totalHp = data.snipertHp;
            armor.baseArmor = data.snipertArmor;
            playerMovement.speed = data.sniperSpeed;
            playerMovement.jump = data.sniperJump;
            classWeapons = data.sniperWeapons;
            skill = data.sniperSkills;
        }
        if (playerJob == Jobs.Support)
        {
            life.totalHp = data.supportHp;
            armor.baseArmor = data.supportArmor;
            playerMovement.speed = data.supportSpeed;
            playerMovement.jump = data.supportJump;
            classWeapons = data.supportWeapons;
            skill = data.supportSkills;
        }
        if (playerJob == Jobs.Engineer)
        {
            life.totalHp = data.engineertHp;
            armor.baseArmor = data.engineerArmor;
            playerMovement.speed = data.engineerSpeed;
            playerMovement.jump = data.engineerJump;
            classWeapons = data.engineerWeapons;
            skill = data.engineerSkills;
        }

        playerMovement.gravityForce = data.gravityForce;
        playerMovement.camerdaSpeed = data.camerdaSpeed;
        playerMovement.cameraRotationY = data.cameraRotationY;
    }
}
