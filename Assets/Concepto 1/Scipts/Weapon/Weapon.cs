using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public GameObject bullet;
    public AudioClip reloadSound;
    AudioSource aSource;
    [SerializeField]
    int totalAmmo;
    int currentAmmo;
    [SerializeField]
    int magazine;
    int currentMagazine;
    [SerializeField]
    float cadence;
    [SerializeField]
    Transform shotPoint;
    [SerializeField]
    Transform firePoint;
    [SerializeField]
    float reloadSpeed;
    Shooter shooter;

    protected void Awake()
    {
        aSource = GetComponent<AudioSource>();
        shooter = GetComponentInParent<Shooter>();
    }

    // Funcion encargada de instanciar una municion en punto de disparo
    public virtual void FireBullet()
    {
        GameObject shot = Instantiate(bullet);
        shot.transform.position = shotPoint.position;
        shot.transform.rotation = shotPoint.rotation;
    }

    // Funcion encargada de recargar e inpedir que se pueda disparar mientras se recargar y que la recarga no sea instantanea
    public virtual void Reload() {
        Invoke("ReloadAction", reloadSpeed);
        shooter.enabled = false;
    }

    // Controla que al recarcar el cargador se llene a medida que el pool de municiones se vasie
    protected virtual void ReloadAction()
    {
        aSource.clip = reloadSound;
        aSource.Play();
        if(currentAmmo > 0)
        {
            while(currentAmmo > 0 & currentMagazine < magazine)
            {
                currentAmmo -= 1;
                currentMagazine += 1;
            }
        }
        shooter.enabled = true;
    }

    // Funcion para aplicar algun powerUp al arma
    public virtual void PowerUp()
    {
        
    }

    // Disparo primario
    public virtual void PrimaryFire()
    {

    }

    // Disparo Secundario
    public virtual void SecondaryFire()
    {

    }

    // Funcion especial del arma
    public virtual void SpecialFire()
    {

    }
}
