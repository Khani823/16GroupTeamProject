using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    //Text[] txt;
    [SerializeField]
    private Slider hpbar;

    private float maxHp = 100;
    private float curHp = 100;
    float imsi;

    void Start()
    {
        hpbar.value = (float) curHp / (float) maxHp;

        //for(int i = 0; i < txt.Length; i++)
        //{
        //    txt[i].text = KeySetting.keys[(KeyAction)i].ToString();
        //}        
    }
        
    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ü���� 0���� ũ��
            if (curHp > 0)
            {
                // ü�� 1�� ����
                curHp -= 1;
            }
            else
            {
                // ü���� 0�̸� �״�� ����
                curHp = 0;
            }
            // ü�� ���� ��� �� ����
            imsi = (float) curHp / (float)maxHp;
        }
        // ü���� ó���ϴ� �޼��� ȣ��
        HandleHp();

        //for (int i = 0; i < txt.Length; i++)
        //{
        //    txt[i].text = KeySetting.keys[(KeyAction)i].ToString();
        //}
    }

    private void HandleHp()
    {
        // ü�¹ٰ� �ε巴�� �پ��� ����
        hpbar.value = Mathf.Lerp(hpbar.value, imsi, Time.deltaTime * 1);
    }
    
}
