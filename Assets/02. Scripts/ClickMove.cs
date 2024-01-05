using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickMove : MonoBehaviour
{
    NavMeshAgent agent;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // 충돌한 지점의 정보를 저장
            RaycastHit2D hit2d = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit2d.collider != null && hit2d.collider.CompareTag("Ground"))
            {

                // 네비게이션 메시 에이전트의 목적지 설정
                agent.SetDestination(hit2d.point);


            }
        }
        
    }
}
