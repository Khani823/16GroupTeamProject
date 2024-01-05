using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    public float movementRange = 2f; // 이동 가능한 범위

    private GameObject selectedObject;
    private Vector2 initialPosition;

    void Update()
    {
        // 마우스 왼쪽 버튼이 클릭되었을 때
        if (Input.GetMouseButtonDown(0))
        {
            // 마우스 위치를 2D 좌표로 변환
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // 레이의 시작점
            Vector2 origin = mousePosition;

            // 레이의 방향 (2D에서는 z 방향이 필요하지 않으므로 Vector3.forward를 사용)
            Vector3 direction = Vector3.forward;

            // 2D Ray 생성
            Ray2D ray = new Ray2D(origin, direction);

            // Raycast를 이용하여 오브젝트 선택
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            // 충돌이 감지되면
            if (hit.collider != null)
            {
                // 선택된 오브젝트 처리
                selectedObject = hit.collider.gameObject;
                initialPosition = selectedObject.transform.position;

                // 이동 가능한 범위를 시각적으로 표현
                DrawMovementRange(selectedObject.transform.position, movementRange);
            }
        }

        // 마우스 오른쪽 버튼이 클릭되었을 때
        if (Input.GetMouseButtonDown(1) && selectedObject != null)
        {
            // 마우스 위치를 2D 좌표로 변환
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // 선택된 오브젝트 이동
            MoveObject(mousePosition);
        }
    }

    void MoveObject(Vector2 targetPosition)
    {
        // 이동 가능한 범위 내에서만 이동 처리
        float distance = Vector2.Distance(initialPosition, targetPosition);
        if (distance <= movementRange)
        {
            selectedObject.transform.position = targetPosition;
        }

        // 이동 후 초기화
        selectedObject = null;
        initialPosition = Vector2.zero;
    }

    void DrawMovementRange(Vector2 center, float radius)
    {
        // 이동 가능한 범위를 원으로 시각적으로 표현
        DebugDraw.Circle(center, radius, Color.green, 0.1f);
    }
}

public static class DebugDraw
{
    // 원을 그리기 위한 함수
    public static void Circle(Vector2 center, float radius, Color color, float duration = 0)
    {
        int segments = 36; // 원을 구성하는 세그먼트 수
        float angleIncrement = 360f / segments;

        for (int i = 0; i < segments; i++)
        {
            float angle1 = Mathf.Deg2Rad * i * angleIncrement;
            float angle2 = Mathf.Deg2Rad * (i + 1) * angleIncrement;

            Vector2 point1 = center + new Vector2(Mathf.Cos(angle1) * radius, Mathf.Sin(angle1) * radius);
            Vector2 point2 = center + new Vector2(Mathf.Cos(angle2) * radius, Mathf.Sin(angle2) * radius);

            Debug.DrawLine(point1, point2, color, duration);
        }
    }
}
