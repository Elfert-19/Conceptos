using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Class_Data")]
public class Class_Data : ScriptableObject {
    public float assaultHp;
    public float assaultSpeed;
    public float assaultArmor;
    public float assaultJump;
    public Weapon[] assaultWeapons;
    public Skill[] assaultSkills;

    public float snipertHp;
    public float sniperSpeed;
    public float snipertArmor;
    public float sniperJump;
    public Weapon[] sniperWeapons;
    public Skill[] sniperSkills;

    public float supportHp;
    public float supportSpeed;
    public float supportArmor;
    public float supportJump;
    public Weapon[] supportWeapons;
    public Skill[] supportSkills;

    public float engineertHp;
    public float engineerSpeed;
    public float engineerArmor;
    public float engineerJump;
    public Weapon[] engineerWeapons;
    public Skill[] engineerSkills;

    public float gravityForce;
    public float camerdaSpeed;
    public float cameraRotationY;
}
