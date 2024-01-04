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
            // 체력이 0보다 크면
            if (curHp > 0)
            {
                // 체력 1씩 감소
                curHp -= 1;
            }
            else
            {
                // 체력이 0이면 그대로 유지
                curHp = 0;
            }
            // 체력 비율 계산 및 저장
            imsi = (float) curHp / (float)maxHp;
        }
        // 체력을 처리하는 메서드 호출
        HandleHp();

        //for (int i = 0; i < txt.Length; i++)
        //{
        //    txt[i].text = KeySetting.keys[(KeyAction)i].ToString();
        //}
    }

    private void HandleHp()
    {
        // 체력바가 부드럽게 줄어들게 해줌
        hpbar.value = Mathf.Lerp(hpbar.value, imsi, Time.deltaTime * 1);
    }
    
}
