using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    public Door linkedDoor; // 연결된 문
    public float interactionDistance = 1.0f; // 상호작용 가능한 최대 거리

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsPlayerInInteractionRange())
        {
            linkedDoor.OpenDoor();
        }
    }

    private bool IsPlayerInInteractionRange()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float distance = Vector2.Distance(player.transform.position, transform.position);

        // 플레이어가 스위치에 충분히 가까운지 확인
        if (distance <= interactionDistance)
        {
            // 플레이어가 스위치를 향하고 있는지 확인 (선택적)
            Vector2 directionToSwitch = (transform.position - player.transform.position).normalized;
            float dotProduct = Vector2.Dot(player.transform.up, directionToSwitch);
            if (dotProduct > 0.8) // 플레이어가 스위치를 대략적으로 향하고 있음
            {
                return true;
            }
        }
        return false;
    }
}
