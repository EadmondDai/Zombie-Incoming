using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyWeapon : MonoBehaviour
{
    [SerializeField] Camera myCamera;
    [SerializeField] float range = 100f;
    [SerializeField] int damage = 10;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffectObj;
    [SerializeField] float hitEffectLifeTime = 0.3f;
    [SerializeField] Ammo ammoScript;
    [SerializeField] AmmoType ammoType;

    bool canShoot = true;
    [SerializeField] float timeBewtweenShots = 0.5f;



    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            if (ammoScript.GetAmmoAmount(ammoType) > 0)
            {

                StartCoroutine(Shoot(ammoType));
            }
        }        
    }

    IEnumerator Shoot(AmmoType ammoType)
    {
        canShoot = false;
        CheckHit();
        PlayMuzzleFlash();
        ammoScript.DecreaseCurAmmo(ammoType);
        yield return new WaitForSeconds(timeBewtweenShots);
        canShoot = true;
    }

    void CheckHit()
    {
        RaycastHit hit;
        if (Physics.Raycast(myCamera.transform.position, myCamera.transform.forward, out hit, range))
        {
            PlayHitEffect(hit);
            EnemyHealth health = hit.transform.GetComponent<EnemyHealth>();
            if (health)
                health.OnHit(damage);
        }
    }

    void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    void PlayHitEffect(RaycastHit hit)
    {
        var hitEffect = Instantiate(hitEffectObj, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(hitEffect, hitEffectLifeTime);
    }

    void OnEnable()
    {
        canShoot = true;
    }
}
