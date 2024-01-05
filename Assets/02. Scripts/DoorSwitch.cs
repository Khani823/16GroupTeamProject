using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    public Door linkedDoor; // 연결된 문
    public float interactionDistance = 1.0f; // 상호작용 가능한 최대 거리
    public string playerTag = "Player"; // 플레이어 태그

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsPlayerInInteractionRange())
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject) // 스위치를 클릭했는지 확인
            {
                linkedDoor.ToggleDoor();
            }
        }
    }

    private bool IsPlayerInInteractionRange()
    {
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        if (player != null)
        {
            float distance = Vector2.Distance(player.transform.position, transform.position);
            return distance <= interactionDistance;
        }
        return false;
    }
}