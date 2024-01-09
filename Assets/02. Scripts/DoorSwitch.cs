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
            Debug.Log("마우스 클릭");
            Vector3 mouseScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.up, Mathf.Infinity);
            Debug.DrawRay(mousePosition, Vector2.up * 10f, Color.red, 2f);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                Debug.Log("오브젝트 감지: " + hit.collider.gameObject.name);
                Debug.Log("스위치 클릭");
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
            Debug.Log("거리: " + distance);
            return distance <= interactionDistance;
        }
        return false;
    }
}