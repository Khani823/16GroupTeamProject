using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Sword : WeaponAttack
{
    

    //private void Start()
    //{
    //    TestController.OnDirectionChange += UpdateDirection;
    //}

    //private void OnDestroy()
    //{
    //    TestController.OnDirectionChange -= UpdateDirection;
    //}

    //private void UpdateDirection(Vector2 newDirection)
    //{
    //    ClearRangeBoxes();
    //    lookDirection = newDirection;
    //    ShowAttackRange(lookDirection);
    //}

    //private void ClearRangeBoxes()
    //{
    //    foreach (var rangeBox in rangeBoxes)
    //    {
    //        Destroy(rangeBox);
    //    }
    //    rangeBoxes.Clear();
    //}

    public override void Attack(Vector2 direction)
    {
        CheckAttackRange(direction);
        CheckAttackRange(Quaternion.Euler(0, 0, 90) * direction);
        CheckAttackRange(Quaternion.Euler(0, 0, -90) * direction);
    }

    public override void ShowAttackRange(Vector2 direction)
    {
        Vector2 frontPosition = (Vector2)transform.position + direction;
        CreateRangeBoxAtPosition(frontPosition);

        Vector2 leftPosition = (Vector2)transform.position + (Vector2)(Quaternion.Euler(0, 0, 90) * direction);
        CreateRangeBoxAtPosition(leftPosition);

        Vector2 rightPosition = (Vector2)transform.position + (Vector2)(Quaternion.Euler(0, 0, -90) * direction);
        CreateRangeBoxAtPosition(rightPosition);
    }

    private void CreateRangeBoxAtPosition(Vector2 position)
    {
        Vector2 tile = new Vector2(Mathf.Round(position.x * 2) / 2, Mathf.Round(position.y * 2) / 2);
        GameObject showingBox = Instantiate(rangeBox, tile, Quaternion.identity);
        rangeBoxes.Add(showingBox);
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        DrawAttackRay(Quaternion.Euler(0, 0, 90) * lookDirection);
        DrawAttackRay(Quaternion.Euler(0, 0, -90) * lookDirection);
    }
}