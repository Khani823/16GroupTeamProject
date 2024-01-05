using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    public float movementRange = 2f; // �̵� ������ ����

    private GameObject selectedObject;
    private Vector2 initialPosition;

    void Update()
    {
        // ���콺 ���� ��ư�� Ŭ���Ǿ��� ��
        if (Input.GetMouseButtonDown(0))
        {
            // ���콺 ��ġ�� 2D ��ǥ�� ��ȯ
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // ������ ������
            Vector2 origin = mousePosition;

            // ������ ���� (2D������ z ������ �ʿ����� �����Ƿ� Vector3.forward�� ���)
            Vector3 direction = Vector3.forward;

            // 2D Ray ����
            Ray2D ray = new Ray2D(origin, direction);

            // Raycast�� �̿��Ͽ� ������Ʈ ����
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            // �浹�� �����Ǹ�
            if (hit.collider != null)
            {
                // ���õ� ������Ʈ ó��
                selectedObject = hit.collider.gameObject;
                initialPosition = selectedObject.transform.position;

                // �̵� ������ ������ �ð������� ǥ��
                DrawMovementRange(selectedObject.transform.position, movementRange);
            }
        }

        // ���콺 ������ ��ư�� Ŭ���Ǿ��� ��
        if (Input.GetMouseButtonDown(1) && selectedObject != null)
        {
            // ���콺 ��ġ�� 2D ��ǥ�� ��ȯ
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // ���õ� ������Ʈ �̵�
            MoveObject(mousePosition);
        }
    }

    void MoveObject(Vector2 targetPosition)
    {
        // �̵� ������ ���� �������� �̵� ó��
        float distance = Vector2.Distance(initialPosition, targetPosition);
        if (distance <= movementRange)
        {
            selectedObject.transform.position = targetPosition;
        }

        // �̵� �� �ʱ�ȭ
        selectedObject = null;
        initialPosition = Vector2.zero;
    }

    void DrawMovementRange(Vector2 center, float radius)
    {
        // �̵� ������ ������ ������ �ð������� ǥ��
        DebugDraw.Circle(center, radius, Color.green, 0.1f);
    }
}

public static class DebugDraw
{
    // ���� �׸��� ���� �Լ�
    public static void Circle(Vector2 center, float radius, Color color, float duration = 0)
    {
        int segments = 36; // ���� �����ϴ� ���׸�Ʈ ��
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
