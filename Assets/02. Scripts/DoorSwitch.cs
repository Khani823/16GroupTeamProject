using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    public Door linkedDoor; // ����� ��
    public float interactionDistance = 1.0f; // ��ȣ�ۿ� ������ �ִ� �Ÿ�
    public string playerTag = "Player"; // �÷��̾� �±�

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsPlayerInInteractionRange())
        {
            //Debug.Log("���콺 Ŭ��");
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject) // ����ġ�� Ŭ���ߴ��� Ȯ��
            {
                //Debug.Log("������Ʈ ����: " + hit.collider.gameObject.name);
                //Debug.Log("����ġ Ŭ��");
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
            //Debug.Log("�Ÿ�: " + distance);
            return distance <= interactionDistance;
        }
        return false;
    }
}