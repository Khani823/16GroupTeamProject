using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlObj : MonoBehaviour
{
    public float interactionRange = 1.0f; //�νĹ���
    public string playerTag = "Player"; // �÷��̾��±�

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 Ŭ�� ����
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject) // Box�� Ŭ���ߴ��� Ȯ��
            {
                GameObject player = GameObject.FindGameObjectWithTag(playerTag);
                if (player != null && Vector2.Distance(player.transform.position, transform.position) <= interactionRange) //�Ÿ� Ȯ��
                {
                    AcquireKey(); // KEY ������ ȹ��
                }
            }
        }
    }


    void AcquireKey()
    {
        // KEY ������ ȹ�� ó��
        //Debug.Log("KEY ������ ȹ��!");
        //�κ��丮�� ������ �߰� ���� ��
    }
}
