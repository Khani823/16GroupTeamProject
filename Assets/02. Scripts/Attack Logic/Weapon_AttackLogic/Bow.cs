using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Bow : MonoBehaviour
{
    public float range = 4f;
    public LayerMask targetlayer;
    public Vector2 lookDirection;
    public GameObject rangeBox;
    public GameObject rangeShower;
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
        Vector2 position = (Vector2)transform.position + new Vector2(0f, -0.15f);
        RaycastHit2D hit = Physics2D.Raycast(position, direction, range, targetlayer);

        for (int i = 1; i <= range; i++)
        {
            Vector2 boxPosition = position + direction * i;
            GameObject boxPrefab;
            if (hit.collider != null && hit.distance >= i)
            {
                boxPrefab = rangeShower; // 회색 상자
                Debug.Log($"Creating grey box at {boxPosition}");

            }
            else
            {
                boxPrefab = rangeBox; // 빨간 상자
                Debug.Log($"Creating red box at {boxPosition}");

            }

            GameObject showingBox = Instantiate(boxPrefab, boxPosition, Quaternion.identity);
            rangeBoxes.Add(showingBox);

            if (hit.collider != null && hit.distance < i)
                break;
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
