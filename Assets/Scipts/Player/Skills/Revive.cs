using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revive : Skill {
    [SerializeField]
    float maxDistance;
    [SerializeField]
    LayerMask layer;
    Camera playerCamera;

    private void Awake()
    {
        playerCamera = GetComponentInParent<PlayerClass>().playerCamera;
    }

    public override void UseSkill()
    {
        if (used == false)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, playerCamera.transform.forward, out hit, maxDistance, layer))
            {
                Life hitLife = hit.collider.GetComponent<Life>();
                if (hitLife.dead == true)
                {
                    hitLife.Revive();
                    used = true;
                    SkillColdown();
                    Debug.DrawLine(transform.position, hit.point, Color.blue);
                }
            }
        }
    }
}
