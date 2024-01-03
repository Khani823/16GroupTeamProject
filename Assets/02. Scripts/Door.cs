using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false;

    public void OpenDoor()
    {
        isOpen = true;
        // 문 열리는 애니메이션 또는 시각적 변화 처리
    }

    public void CloseDoor()
    {
        isOpen = false;
        // 문 닫히는 애니메이션 또는 시각적 변화 처리
    }
}
