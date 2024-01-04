using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttackController : MonoBehaviour
{
    private PlayerController2D attackInput;
    public  WeaponAttack currentWeapon;

    private void Awake()
    {
        attackInput = new PlayerController2D();
    }

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