using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy_Data")]
public class Type_Data : ScriptableObject {

    public float smallHp;
    public float smallSpeed;
    public float smallArmor;
    public float smallMeleeDamage;
    public float smallVisionRange;
    public LayerMask smallLayerVision;

    public float mediumlHp;
    public float mediumSpeed;
    public float mediumArmor;
    public float mediumRangeDamage;
    public float mediumVisionRange;
    public LayerMask mediumLayerVision;

    public float bigHp;
    public float bigSpeed;
    public float bigArmor;
    public float bigMeleeDamage;
    public float bigRangeDamage;
    public float bigVisionRange;
    public LayerMask bigLayerVision;

    public float bossHp;
    public float bossSpeed;
    public float bossArmor;
    public float bossMeleeDamage;
    public float bossRangeDamage;
    public float bossVisionRange;
    public LayerMask bossLayerVision;
}
