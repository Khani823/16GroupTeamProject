using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

// Ű �Է� ������ �����ϴ� ������
public enum KeyAction { UP, DOWN, LEFT, RIGHT, KEYCOUNT }

// Ű ������ �����ϴ� ���� Ŭ����
public static class KeySetting 
{
    // �� ���ۿ� ���� �⺻ Ű�� �����ϴ� ��ųʸ�
    public static Dictionary<KeyAction, KeyCode> keys = new Dictionary<KeyAction, KeyCode>();
}

public class KeyManager : MonoBehaviour
{
    // �⺻ Ű �迭
    KeyCode[] defaultKeys = new KeyCode[] {KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D};
    private void Awake()
    {
        // �ʱ�ȭ �� �⺻ Ű�� ���� ��ųʸ��� �߰�
        for (int i = 0; i < (int)KeyAction.KEYCOUNT; i++)
        {
            KeySetting.keys.Add((KeyAction)i, defaultKeys[i]);
        }
    }

    private void OnGUI()
    {
        // ���� �̺�Ʈ�� ������
        Event keyEvent = Event.current;

        // Ű �Է��� �����Ǹ�
        if (keyEvent.isKey)
        {
            // �����Ϸ��� Ű ���ۿ� ���� Ű�ڵ带 ���� ��ųʸ��� ������Ʈ
            KeySetting.keys[(KeyAction)key] = keyEvent.keyCode;
            // Ű �����ʱ�ȭ
            key = -1;
        }
    }

    // ������ Ű ������ �����ϴ� ����
    int key = -1;

    // Ű ���� ��û�� �޾ƿ��� �޼���
    public void ChangeKey(int num)
    {
        key = num;
    }
}
