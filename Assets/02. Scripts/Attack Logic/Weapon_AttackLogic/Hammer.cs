using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public float range = 2f;
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
        ClearRangeBoxes();
    }


    private void CheckAttackRange(Vector2 direction)
    {
        Vector2 position = transform.position;
        RaycastHit2D[] hits = Physics2D.RaycastAll(position, direction, range, targetlayer);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider != null)
            {
                Debug.Log("맞았습니다! 대상: " + hit.collider.gameObject.name);
            }
        }
        
    }

    private void ShowAttackRange(Vector2 direction)
    {
        for(float i = 1; i<=range; i++)
        {
            Vector2 basePosition = (Vector2)transform.position + (direction * i);
            Vector2 tile = new Vector2(Mathf.Round(basePosition.x * 2) / 2, Mathf.Round(basePosition.y * 2) / 2);
            GameObject showingBox = Instantiate(rangeBox, tile, Quaternion.identity);
            rangeBoxes.Add(showingBox);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        DrawAttackRay(lookDirection);
    }

    private void DrawAttackRay(Vector2 direction)
    {
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + direction * range);
    }
}