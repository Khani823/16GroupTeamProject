using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false;

    public void OpenDoor()
    {
        isOpen = true;
        // �� ������ �ִϸ��̼� �Ǵ� �ð��� ��ȭ ó��
    }

    public void CloseDoor()
    {
        isOpen = false;
        // �� ������ �ִϸ��̼� �Ǵ� �ð��� ��ȭ ó��
    }
}
