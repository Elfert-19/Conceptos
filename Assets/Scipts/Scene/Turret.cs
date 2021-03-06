﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
    public float duration;
    Collider[] detections = null;
    [SerializeField]
    float maxDistance;
    [SerializeField]
    LayerMask layer;
    public Transform firePoint;
    public float cadence;
    public float damage;
    float shotTime;
    bool isOn;
    Armor targetArmor;
    Life targetHp;
    public GameObject shotEffect;
    int currentObjetive;
    public bool active;

    private void Awake()
    {
        detections = new Collider[15];
        Invoke("FinishTurret", duration);
    }

    private void OnEnable()
    {
        Invoke("FinishTurret", duration);
        active = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        PerimetralCheck();
    }

    private void Update()
    {
        if(isOn == true)
        {
            if (currentObjetive < detections.Length)
            {
                gameObject.transform.LookAt(detections[currentObjetive].gameObject.transform.position);
                FireIntruder();
            }
            else
            {
                isOn = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PerimetralCheck();
    }
    // Chekea todos los enemigos del area designada y los acomoda en un array
    public void PerimetralCheck()
    {
        Physics.OverlapSphereNonAlloc(transform.position, maxDistance, detections ,layer);
        if(detections.Length > 0)
        {
            isOn = true;
        }
        else
        {
            isOn = false;
        }
    }
    // Dispara al enemigo en la primera posicion del array de deteccion;
    public void FireIntruder()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(firePoint.position, firePoint.transform.forward, out hitInfo, maxDistance, layer))
        {   
            targetHp = hitInfo.collider.GetComponent<Life>();
            targetArmor = hitInfo.collider.GetComponent<Armor>();
            if (targetHp.dead == false)
            {
                if (Time.time - shotTime > cadence)
                {
                    Instantiate(shotEffect, firePoint.transform.position, firePoint.transform.rotation);
                    targetArmor.ApplyArmor(damage);
                    shotTime = Time.time;
                }
            }
        }
        else
        {
            currentObjetive += 1;
        }
    }
    // Cunado finalisa el efecto de la torreta
    public void FinishTurret()
    {
        gameObject.SetActive(false);
        currentObjetive = 0;
    }

    private void OnDisable()
    {
        active = false;
    }
}
