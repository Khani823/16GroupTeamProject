using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    public Hammer sword;
    private Vector2 lookDirection = Vector2.up;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        { 
	        lookDirection = Vector2.up;
            Debug.Log("위");
	    }

        if (Input.GetKeyDown(KeyCode.S))
        {
            lookDirection = Vector2.down;
            Debug.Log("아래");
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            lookDirection = Vector2.left;
            Debug.Log("왼");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            lookDirection = Vector2.right;
            Debug.Log("오");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sword.Attack(lookDirection);
            Debug.Log("attack");
        }
        sword.lookDirection = lookDirection;
    }
}
