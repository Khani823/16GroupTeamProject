using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponAttack : MonoBehaviour
{
    public float range;
    public LayerMask targetlayer;
    public Vector2 lookDirection;
    public GameObject rangeBox;
    protected List<GameObject> rangeBoxes = new List<GameObject>();

    protected virtual void Start()
    {
        TestController.OnDirectionChange += UpdateDirection;
    }

    protected void UpdateDirection(Vector2 newDirection)
    {
        ClearRangeBoxes();
        lookDirection = newDirection;
        ShowAttackRange(lookDirection);
    }

    public abstract void Attack();

    protected virtual void ShowAttackRange(Vector2 direction)
    {
        // 공격 범위 표시 로직 구현
    }

    protected void ClearRangeBoxes()
    {
        foreach (var box in rangeBoxes)
        {
            Destroy(box);
        }
        rangeBoxes.Clear();
    }

    // 기타 공통 메서드...
}
