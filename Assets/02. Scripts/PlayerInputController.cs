using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : CharacterController
{
    public GameObject Menu;
    private Camera _camera;
    //private Animator _animator;
    private Vector2 moveInput;
    private void Awake()
    {
     
        DontDestroyOnLoad(gameObject);
        _camera = Camera.main;
       // _animator = GetComponent<Animator>();
    }
    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        SetMovementAnimation();
    }

    private void SetMovementAnimation()
    {
        // Set the appropriate animations based on the input direction
        if (moveInput.magnitude > 0)
        {
            //_animator.SetInteger("Horizontal", (int)Mathf.Sign(moveInput.x));
            //_animator.SetInteger("Vertical", (int)Mathf.Sign(moveInput.y));
            //_animator.SetBool("IsMoving", true);

            if (moveInput.x > 0)
            {
                // Set animation for moving to the right
            }
            else if (moveInput.x < 0)
            {
                // Set animation for moving to the left
            }

            if (moveInput.y > 0)
            {
                // Set animation for moving up
            }
            else if (moveInput.y < 0)
            {
                // Set animation for moving down
            }
        }
        else
        {
            // If there is no input, set idle or stop movement animation
            //_animator.SetInteger("Horizontal", 0);
            //_animator.SetInteger("Vertical", 0);
            //_animator.SetBool("IsMoving", false);
        }
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        SetMovementAnimation();
        CallMoveEvent(moveInput);
    }

    //public void OnLook(InputValue value)
    //{
    //    Vector2 newAim = value.Get<Vector2>();
    //    Vector2 worldPos = _camera.ScreenToWorldPoint(newAim);
    //    newAim = (worldPos - (Vector2)transform.position).normalized;

    //    if (newAim.magnitude >= .9f)
    //    {
    //        CallLookEvent(newAim);
    //    }
    //}
    public void OnInventory()
    {
        Menu.SetActive(true);
    }
    //public void OnMouseMove(InputValue value)
    //{
    //    bool moveInput = value.isPressed;
    //    CallMouseMoveEvent(moveInput);
    //}
}
