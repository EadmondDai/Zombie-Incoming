using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwtich : MonoBehaviour
{
    [SerializeField] int activeWeapon = 0;
    [SerializeField] float mouseScrollSensitivity = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        SetActiveWeapon(activeWeapon);
    }

    void GetNextWeapon()
    {
        activeWeapon++;
        if(activeWeapon >= transform.childCount)
        {
            activeWeapon = 0;
        }
    }

    void GetPreWeapon()
    {
        activeWeapon--;
        if(activeWeapon < 0)
        {
            activeWeapon = transform.childCount - 1;
        }
    }

    void ProcessScrollWheel()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll < 0)
        {
            GetNextWeapon();
        }
        else if(scroll > 0)
        {
            GetPreWeapon();
        }
    }

    void ProcessInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            activeWeapon = 0;
        }else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            activeWeapon = 1;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            activeWeapon = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int preWeapon = activeWeapon;
        ProcessScrollWheel();
        ProcessInput();

        if(preWeapon != activeWeapon)
        {
            SetActiveWeapon(activeWeapon);
        }
    }

    void SetActiveWeapon(int weaponIdx)
    {
        int curWeapon = 0;
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(curWeapon == activeWeapon);
            curWeapon++;
        }
    }
}
 