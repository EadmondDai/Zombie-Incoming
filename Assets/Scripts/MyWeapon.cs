using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyWeapon : MonoBehaviour
{
    [SerializeField] Camera myCamera;
    [SerializeField] float range = 100f;
    [SerializeField] int damage = 10;
    [SerializeField] ParticleSystem muzzleFlash;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
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
            Debug.Log("I hit " + hit.transform.name);
            EnemyHealth health = hit.transform.GetComponent<EnemyHealth>();
            if (health)
                health.OnHit(damage);
        }
    }

    void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }
}
