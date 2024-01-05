using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    public Vector3 closedPosition; // ���� ������ ���� ��ġ
    public Vector3 openPosition; // ���� ������ ���� ��ġ
    public float speed = 2.0f; // ���� �����̴� �ӵ�
    public bool isOpen = false; // ���� ���� ����

    public void ToggleDoor()
    {
        if (isOpen)
        {
            CloseDoor();
        }
        else
        {
            OpenDoor();
        }
    }

    public void OpenDoor()
    {
        StopAllCoroutines();
        StartCoroutine(MoveDoor(openPosition));
        isOpen = true;
    }

    public void CloseDoor()
    {
        StopAllCoroutines();
        StartCoroutine(MoveDoor(closedPosition));
        isOpen = false;
    }

    private IEnumerator MoveDoor(Vector3 targetPosition)
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
    }
}
