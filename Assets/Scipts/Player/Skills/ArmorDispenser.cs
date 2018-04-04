using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorDispenser : Skill {
    public GameObject pole;
    [SerializeField]
    public ArmorPoleSkill asignedPole = null;
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
        asignedPole = dummy.GetComponentInChildren<ArmorPoleSkill>();
        dummy.transform.position = new Vector3(10, -200, 0);
        dummy.SetActive(false);
        duration = asignedPole.duration;
    }

    private void Update()
    {
        active = asignedPole.active;
    }
    // Dispara un rayo para acomodar el Poste de Armadura
    public override void UseSkill()
    {
        if (active == false)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, playerCamera.transform.forward, out hit, maxDistance, layer))
            {
                dummy.SetActive(true);
                dummy.transform.position = new Vector3(hit.point.x, hit.point.y + 1, hit.point.z);
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
        asignedPole.gameObject.SetActive(false);
        SkillColdown();
    }
}
