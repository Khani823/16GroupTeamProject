using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : Character
{
    private PlayerController2D playerController;
    private Vector2 currentDirection;
    private WeaponAttack weaponAttack;

    protected override void Awake()
    {
        base.Awake();
        playerController = new PlayerController2D();
        weaponAttack = GetComponentInChildren<WeaponAttack>();

        playerController.Player.Move.performed += OnMovePerformed;
        playerController.Player.Move.canceled += OnMoveCanceled;
        playerController.Player.Attack.performed += OnAttackPerformed;
        playerController.Player.Attack.canceled += OnAttackCanceled;
    }
    private void OnEnable()
    {
        playerController.Enable();
    }

    private void OnDisable()
    {
        playerController.Disable();
    }

    public void OnWeaponChanged()
    {
        weaponAttack = FindObjectOfType<WeaponAttack>();
    }

    private void OnAttackPerformed(InputAction.CallbackContext obj)
    {
        if (weaponAttack != null)
        {
            weaponAttack.Attack(currentDirection);
        }
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        currentDirection = context.ReadValue<Vector2>();
        if (Mathf.Abs(currentDirection.x) > Mathf.Abs(currentDirection.y))
        {
            currentDirection = new Vector2(currentDirection.x, 0);
        }
        else
        {
            currentDirection = new Vector2(0, currentDirection.y);
        }
        if (weaponAttack != null)
        {
            weaponAttack.SetLookDirection(currentDirection.normalized);
            weaponAttack.ShowAttackRange(currentDirection.normalized);
        }
    }


    private void OnMoveCanceled(InputAction.CallbackContext context) 
    { }

    private void OnAttackCanceled(InputAction.CallbackContext obj)
    { }



    protected override void PerformAction()
    {
        throw new System.NotImplementedException();
    }

    public override void EnableTurnAction()
    {
        base.EnableTurnAction();
        playerController.Enable();
    }

    public override void DisableTurnAction()
    {
        base.DisableTurnAction();
        playerController.Disable();
    }
}
