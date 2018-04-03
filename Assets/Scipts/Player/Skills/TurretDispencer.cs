using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDispencer : Skill {
    public GameObject pole;
    [SerializeField]
    public Turret asignedTurret = null;
    public Camera playerCamera;
    [SerializeField]
    float maxDistance;
    [SerializeField]
    LayerMask layer;
    GameObject dummy;
    bool active = false;

    private void Awake()
    {
        playerCamera = GetComponentInParent<PlayerClass>().playerCamera;
        dummy = Instantiate(pole);
        asignedTurret = dummy.GetComponentInChildren<Turret>();
        dummy.transform.position = new Vector3(15, -200, 0);
        dummy.SetActive(false);
        duration = asignedTurret.duration;
    }

    private void Update()
    {
        active = asignedTurret.active;
    }

    public override void UseSkill()
    {
        if (active == false)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, playerCamera.transform.forward, out hit, maxDistance, layer))
            {
                dummy.SetActive(true);
                dummy.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                Debug.DrawLine(transform.position, hit.point, Color.blue);
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
        asignedTurret.gameObject.SetActive(false);
        SkillColdown();
    }
}
