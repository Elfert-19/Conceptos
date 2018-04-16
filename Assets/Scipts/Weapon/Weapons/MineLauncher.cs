using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineLauncher : Weapon {

    public int totalMinesActives;
    int minesActives;
    GameObject[] minesPlaces;
    public float mineLifeTime;

    private void Start()
    {
        minesPlaces = new GameObject[totalMinesActives];
        InvokeRepeating("MineControl", 1, 1);
    }

    public override void PrimaryFire()
    {
        if (currentMagazine > 0)
        {
            if (minesActives < totalMinesActives)
            {
                FireBullet(Vector3.zero);
            }
        }
    }

    public override void FireBullet(Vector3 hitPoint)
    {
        GameObject mineLaunched = Instantiate(bullet, firePoint.position, firePoint.rotation);
        mineLaunched.GetComponent<Mine>().mineLauncher = this;
        if(minesPlaces[minesActives] == null)
        {
            minesPlaces[minesActives] = mineLaunched;
        }
        if (automatic)
        {
            GameObject particle = Instantiate(shotEffect, firePoint.position, firePoint.rotation, firePoint);
            particle.GetComponent<ParticleDead>().automatic = true;
        }
        else
        {
            Instantiate(shotEffect, firePoint.position, firePoint.rotation, firePoint);
        }
        currentMagazine--;
        minesActives += 1;
    }

    public void MineControl()
    {
        for (int i = 0; i < minesPlaces.Length; i++)
        {
            if (minesPlaces[i] != null)
            {
                Mine mineNumber = minesPlaces[i].GetComponent<Mine>();
                mineNumber.timeLived += 1;
                if (mineNumber.timeLived >= mineLifeTime)
                {
                    mineNumber.Explosion();
                    minesPlaces[i] = null;
                    minesActives -= 1;
                    Destroy(mineNumber.gameObject);
                }
            }
        }
    }

    public void MineRemoved(GameObject mineToRemove)
    {
        for (int i = 0; i < minesPlaces.Length; i++)
        {
            if (minesPlaces[i] != null)
            {
                if (minesPlaces[i].GetInstanceID() == mineToRemove.GetInstanceID())
                {
                    minesPlaces[i] = null;
                }
            }
        }
    }
}
