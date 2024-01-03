using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public float range = 1f;
    public LayerMask targetlayer;
    public Vector2 lookDirection;

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