using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    private WeaponAttack currentWeapon;

    public void SetCurrentWeapon(WeaponAttack weapon)
    {
        currentWeapon = weapon;
    }

    public void Attack()
    {
        if (currentWeapon != null)
        {
            currentWeapon.Attack();
        }
    }
    // Additional Logics to be Updated (if required)
}