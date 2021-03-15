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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(ammoScript.AmmoAmount > 0)
            {
               Shoot();
                ammoScript.DecreaseCurAmmo();
            }
        }        
    }

    void Shoot()
    {
        CheckHit();
        PlayMuzzleFlash();
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
}
