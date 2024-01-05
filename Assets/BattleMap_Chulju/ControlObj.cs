using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlObj : MonoBehaviour
{
    public float interactionRange = 1.0f; //인식범위
    public string playerTag = "Player"; // 플레이어태그

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 클릭 감지
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject) // Box를 클릭했는지 확인
            {
                GameObject player = GameObject.FindGameObjectWithTag(playerTag);
                if (player != null && Vector2.Distance(player.transform.position, transform.position) <= interactionRange) //거리 확인
                {
                    AcquireKey(); // KEY 아이템 획득
                }
            }
        }
    }


    void AcquireKey()
    {
        // KEY 아이템 획득 처리
        //Debug.Log("KEY 아이템 획득!");
        //인벤토리에 아이템 추가 로직 등
    }
}
