using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDead : MonoBehaviour {
    public bool isMuzzle;
    public float duration;

    private void Update()
    {
        ParticcleLife();    
    }

    public void ParticcleLife()
    {
        if (isMuzzle)
        {
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Invoke("Kill", duration);
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
