using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
    public bool hasWeaponRange;
    public float maxDistanceWeaponRange;
    public float numerOfShots;
    public float cadence;
    public Transform firePoint;
    public LayerMask layer;
    public GameObject fireEfect;
    public GameObject bullet;
    public bool hasMelee;
    public float meleDistance;
    public Collider meleeArea;
    float timeBeTwenShots;
    int shotFired;
    float lastShot;

    private void Awake()
    {
        meleeArea.enabled = false;
        timeBeTwenShots = numerOfShots / cadence;
    }

    public void AtackTargetMelee(GameObject target)
    {
        if (hasMelee)
        {
            float targetDistance = Vector3.Distance(transform.position, target.transform.position);
            if (targetDistance <= meleDistance)
            {
                meleeArea.enabled = true;
            }
            meleeArea.enabled = false;
        }
    }

    public void AtackTargetRange(GameObject target)
    {
        if (hasWeaponRange)
        {
            float targetDistance = Vector3.Distance(transform.position, target.transform.position);
            if (targetDistance <= maxDistanceWeaponRange)
            {
                while (shotFired != numerOfShots)
                {
                    if (lastShot >= timeBeTwenShots)
                    {
                        float dispercion = Random.Range(-0.5f, 0.5f);
                        Vector3 direction = firePoint.forward + new Vector3(dispercion, dispercion, dispercion);
                        RaycastHit hit;
                        if (Physics.Raycast(firePoint.position, direction, out hit, maxDistanceWeaponRange, layer))
                        {
                            Instantiate(fireEfect, firePoint);
                            GameObject bulletPosition = Instantiate(bullet);
                            bulletPosition.transform.position = hit.point;
                            shotFired += 1;
                            lastShot = Time.time;
                        }
                    }
                }
            }
            shotFired = 0;
        }
    }
}
