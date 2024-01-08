using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action<Vector2> OnMouseMoveEvent;

    PlayerStat _stat;

    void Start()
    {
        //기본 스탯 정보 가져오기
        _stat = gameObject.GetComponent<PlayerStat>();
    }

        public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
    public void CallMouseMoveEvent(Vector2 direction)
    {
        OnMouseMoveEvent?.Invoke(direction);
    }
}