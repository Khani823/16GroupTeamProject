using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : CharacterController
{
    private Camera _camera;
    private Animator _animator;
    private Vector2 moveInput;
    private void Awake()
    {
        _camera = Camera.main;
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        SetMovementAnimation();
    }

    void SetMovementAnimation()
    {
        if (moveInput.magnitude > 0)
        {
            _animator.SetInteger("Horizontal", (int)moveInput.x);
            _animator.SetInteger("Vertical", (int)moveInput .y);
            _animator.SetBool("IsChange", true);

            if (moveInput.x > 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (moveInput.x < 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        
        else
        {
            _animator.SetInteger("Horizontal", 0);
            _animator.SetInteger("Vertical", 0);
            _animator.SetBool("IsChange", false);
        }
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;

        if (newAim.magnitude >= .9f)
        {
            CallLookEvent(newAim);
        }
    }
    //public void OnMouseMove(InputValue value)
    //{
    //    bool moveInput = value.isPressed;
    //    CallMouseMoveEvent(moveInput);
    //}
}
