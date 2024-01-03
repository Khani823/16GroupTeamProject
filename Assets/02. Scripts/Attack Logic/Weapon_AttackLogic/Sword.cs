using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Sword : MonoBehaviour
{
    public float range = 1f;
    public LayerMask targetlayer;
    public Vector2 lookDirection;
    public GameObject rangeBox;
    private List<GameObject> rangeBoxes = new List<GameObject>();

    private void Start()
    {
        TestController.OnDirectionChange += UpdateDirection;
    }

    private void OnDestroy()
    {
        TestController.OnDirectionChange -= UpdateDirection;
    }

    private void UpdateDirection(Vector2 newDirection)
    {
        ClearRangeBoxes();
        lookDirection = newDirection;
        ShowAttackRange(lookDirection);
    }

    private void ClearRangeBoxes()
    {
        foreach (var rangeBox in rangeBoxes)
        {
            Destroy(rangeBox);
        }
        rangeBoxes.Clear();
    }

    public void Attack(Vector2 direction)
    {
        CheckAttackRange(direction);
        CheckAttackRange(Quaternion.Euler(0, 0, 90) * direction);
        CheckAttackRange(Quaternion.Euler(0, 0, -90) * direction);
    }

  
    private void CheckAttackRange(Vector2 direction)
    {
        Vector2 position = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(position, direction, range, targetlayer);
        if (hit.collider != null)
        {
            Debug.Log("맞았습니다! 대상: " + hit.collider.gameObject.name);
        }
    }

    private void ShowAttackRange(Vector2 direction)
    {
        Vector2 frontPosition = (Vector2)transform.position + direction;
        CreateRangeBoxAtPosition(frontPosition);

        // 왼쪽 방향에 상자 생성
        Vector2 leftPosition = (Vector2)transform.position + (Vector2)(Quaternion.Euler(0, 0, 90) * direction);
        CreateRangeBoxAtPosition(leftPosition);

        // 오른쪽 방향에 상자 생성
        Vector2 rightPosition = (Vector2)transform.position + (Vector2)(Quaternion.Euler(0, 0, -90) * direction);
        CreateRangeBoxAtPosition(rightPosition);
    }

    private void CreateRangeBoxAtPosition(Vector2 position)
    {
        Vector2 tile = new Vector2(Mathf.Round(position.x * 2) / 2, Mathf.Round(position.y * 2) / 2);
        GameObject showingBox = Instantiate(rangeBox, tile, Quaternion.identity);
        rangeBoxes.Add(showingBox);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        DrawAttackRay(lookDirection);
        DrawAttackRay(Quaternion.Euler(0, 0, 90) * lookDirection);
        DrawAttackRay(Quaternion.Euler(0, 0, -90) * lookDirection);
    }

    private void DrawAttackRay(Vector2 direction)
    {
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + direction * range);
    }
}