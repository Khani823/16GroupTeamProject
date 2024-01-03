using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    public Door linkedDoor; // ����� ��
    public float interactionDistance = 1.0f; // ��ȣ�ۿ� ������ �ִ� �Ÿ�

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

        // �÷��̾ ����ġ�� ����� ������� Ȯ��
        if (distance <= interactionDistance)
        {
            // �÷��̾ ����ġ�� ���ϰ� �ִ��� Ȯ�� (������)
            Vector2 directionToSwitch = (transform.position - player.transform.position).normalized;
            float dotProduct = Vector2.Dot(player.transform.up, directionToSwitch);
            if (dotProduct > 0.8) // �÷��̾ ����ġ�� �뷫������ ���ϰ� ����
            {
                return true;
            }
        }
        return false;
    }
}
