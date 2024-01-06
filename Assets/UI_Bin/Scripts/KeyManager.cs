using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

// 키 입력 동작을 정의하는 열거형
public enum KeyAction { UP, DOWN, LEFT, RIGHT, KEYCOUNT }

// 키 설정을 관리하는 정적 클래스
public static class KeySetting 
{
    // 각 동작에 대한 기본 키를 저장하는 딕셔너리
    public static Dictionary<KeyAction, KeyCode> keys = new Dictionary<KeyAction, KeyCode>();
}

public class KeyManager : MonoBehaviour
{
    // 기본 키 배열
    KeyCode[] defaultKeys = new KeyCode[] {KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D};
    private void Awake()
    {
        // 초기화 시 기본 키를 설정 딕셔너리에 추가
        for (int i = 0; i < (int)KeyAction.KEYCOUNT; i++)
        {
            KeySetting.keys.Add((KeyAction)i, defaultKeys[i]);
        }
    }

    private void OnGUI()
    {
        // 현재 이벤트를 가져옴
        Event keyEvent = Event.current;

        // 키 입력이 감지되면
        if (keyEvent.isKey)
        {
            // 변경하려는 키 동작에 대한 키코드를 설정 딕셔너리에 업데이트
            KeySetting.keys[(KeyAction)key] = keyEvent.keyCode;
            // 키 변수초기화
            key = -1;
        }
    }

    // 변경할 키 동작을 저장하는 변수
    int key = -1;

    // 키 변경 요청을 받아오는 메서드
    public void ChangeKey(int num)
    {
        key = num;
    }
}
