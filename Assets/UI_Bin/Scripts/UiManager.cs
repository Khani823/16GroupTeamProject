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
            if(curHp > 0)
            {
                curHp -= 10;
            }
            else
            {
                curHp = 0;
            }
        }

        HandleHp();

        //for (int i = 0; i < txt.Length; i++)
        //{
        //    txt[i].text = KeySetting.keys[(KeyAction)i].ToString();
        //}
    }

    private void HandleHp()
    {
        hpbar.value = Mathf.Lerp(hpbar.value, (float)curHp / (float)maxHp, Time.deltaTime * 10);
    }
    
}
