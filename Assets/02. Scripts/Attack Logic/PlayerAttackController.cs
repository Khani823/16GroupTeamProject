using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    public  WeaponAttack currentWeapon;

    public void SetCurrentWeapon(WeaponAttack weapon)
    {
        currentWeapon = weapon;
    }

    public void Attack(Vector2 atkDirection)
    {
        if (currentWeapon != null)
        {
            currentWeapon.Attack(atkDirection);
        }
    }
    // Additional Logics to be Updated (if required)
}