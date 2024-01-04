using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidioOption : MonoBehaviour
{
    // UI�� ��� �� Dropdown
    public Dropdown resolutionDropdown;
    // ����Ʈ�� ��� ������ �ػ� ����
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
        // ��� ������ �ػ� ����Ʈ �߰�
        resolutions.AddRange(Screen.resolutions);
        // ��Ӵٿ� �ʱ�ȭ
        resolutionDropdown.options.Clear();

        //�ػ� �ݺ�
        foreach (Resolution item in resolutions)
        {
            // ��Ӵٿ� �޴��� �ɼ� �߰�
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = item.width + "x" + item.height + " " + item.refreshRate + "hz";
            resolutionDropdown.options.Add(option);
        }
        // ��Ӵٿ� �޴� ����
        resolutionDropdown.RefreshShownValue();
    }
}
