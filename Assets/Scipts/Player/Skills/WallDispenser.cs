using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDispenser : Skill {
    public GameObject wall;
    public Camera playerCamera;
    [SerializeField]
    float maxDistance;
    [SerializeField]
    LayerMask layer;
    GameObject activeWall;
    bool active = false;

    private void Awake()
    {
        playerCamera = GetComponentInParent<PlayerClass>().playerCamera;
        activeWall = Instantiate(wall);
        activeWall.transform.position = new Vector3(-15, -200, 0);
        activeWall.SetActive(false);
    }

    public override void UseSkill()
    {
        if (active == false)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, playerCamera.transform.forward, out hit, maxDistance, layer))
            {
                activeWall.SetActive(true);
                activeWall.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                Debug.DrawLine(transform.position, hit.point, Color.blue);
                Invoke("SkillFinish", duration);
                active = true;
            }
        }
        else
        {
            used = true;
            Invoke("SkillColdown", duration);
        }
    }

    public override void SkillFinish()
    {
        activeWall.SetActive(false);
        SkillColdown();
        active = false;
    }
}
