using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDead : UnityEngine.MonoBehaviour {
    public bool isMuzzle;
    public float duration;
    public bool automatic = false;

    private void Update()
    {
        ParticcleLife();    
    }
    // Controla la destruccion de los efectos
    public void ParticcleLife()
    {
        if (isMuzzle)
        {
            if (automatic)
            {
                if (Input.GetKeyUp(KeyCode.Mouse0))
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                Invoke("Kill", 0.1f);
            }
        }
        else
        {
            Invoke("Kill", duration);
        }
    }
    // Destruye el efecto
    public void Kill()
    {
        Destroy(gameObject);
    }
}
