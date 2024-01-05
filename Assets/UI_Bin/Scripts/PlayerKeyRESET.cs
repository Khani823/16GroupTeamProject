using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeySetting.keys[KeyAction.UP]))
        {
            Debug.Log("UP");
        }
        else if (Input.GetKey(KeySetting.keys[KeyAction.DOWN]))
        {
            Debug.Log("DOWN");
        }
        if (Input.GetKey(KeySetting.keys[KeyAction.LEFT]))
        {
            Debug.Log("LEFT");
        }
        else if (Input.GetKey(KeySetting.keys[KeyAction.RIGHT]))
        {
            Debug.Log("RIGHT");
        }
    }
}
