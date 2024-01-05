using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    public Vector3 closedPosition; // 문이 닫혔을 때의 위치
    public Vector3 openPosition; // 문이 열렸을 때의 위치
    public float speed = 2.0f; // 문이 움직이는 속도
    public bool isOpen = false; // 문의 현재 상태

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
