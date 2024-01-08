using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    public static event Action<Vector2> OnDirectionChange;
    public WeaponAttack curWeapon;
    private Vector2 lookDirection = Vector2.up;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        { 
	        lookDirection = Vector2.up;
            OnDirectionChange?.Invoke(lookDirection);
            Debug.Log("위");
	    }

        if (Input.GetKeyDown(KeyCode.S))
        {
            lookDirection = Vector2.down;
            OnDirectionChange?.Invoke(lookDirection); 
	        Debug.Log("아래");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            lookDirection = Vector2.left;
            OnDirectionChange?.Invoke(lookDirection);
            Debug.Log("왼");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            lookDirection = Vector2.right;
            OnDirectionChange?.Invoke(lookDirection);
            Debug.Log("오");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            curWeapon.Attack(lookDirection);
            Debug.Log("attack");
        }
        curWeapon.lookDirection = lookDirection;
    }
}
