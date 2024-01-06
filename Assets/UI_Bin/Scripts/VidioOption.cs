using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidioOption : MonoBehaviour
{
    // UI에 사용 할 Dropdown
    public Dropdown resolutionDropdown;
    // 리스트에 사용 가능한 해상도 저장
    List<Resolution> resolutions = new List<Resolution>();

    void Start()
    {

    }

    //void InitUI()
    //{
    //    resolutions.AddRange(Screen.resolutions);
    //    foreach (Resolution item in resolutions)
    //    {
    //        Debug.Log(item.width + "x" + item.height + " " + item.refreshRate);
    //    }
    //}


    [System.Obsolete]
    void InitUI()
    {
        // 사용 가능한 해상도 리스트 추가
        resolutions.AddRange(Screen.resolutions);
        // 드롭다운 초기화
        resolutionDropdown.options.Clear();

        //해상도 반복
        foreach (Resolution item in resolutions)
        {
            // 드롭다운 메뉴에 옵션 추가
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = item.width + "x" + item.height + " " + item.refreshRate + "hz";
            resolutionDropdown.options.Add(option);
        }
        // 드롭다운 메뉴 갱신
        resolutionDropdown.RefreshShownValue();
    }
}
