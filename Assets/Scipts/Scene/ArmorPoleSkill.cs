using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorPoleSkill : MonoBehaviour {
    Rigidbody pole;
    [SerializeField]
    float armorIncrement;
    public float duration;
    public float range;
    public bool active = false;
    Armor triggerArmor;

    private void Awake()
    {
        pole = GetComponentInParent<Rigidbody>();
    }

    private void OnEnable()
    {
        Invoke("FinishPole", duration);
        active = true;
    }

    public void OnTriggerStay(Collider hit)
    {
        if(hit.GetComponent<Armor>() != null & hit.tag == "Player")
        {
            triggerArmor = hit.GetComponentInParent<Armor>();
            triggerArmor.extraArmor = armorIncrement;
        }
    }

    public void OnTriggerExit(Collider hit)
    {
        if (hit.GetComponent<Armor>() != null & hit.tag == "Player")
        {
            triggerArmor.extraArmor = -armorIncrement;
        }
    }

    public void FinishPole()
    {
        pole.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        active = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);    
    }
}
