using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidioOption : MonoBehaviour
{
    public Dropdown resolutionDropdown;
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
        resolutions.AddRange(Screen.resolutions);
        resolutionDropdown.options.Clear();

        foreach (Resolution item in resolutions)
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = item.width + "x" + item.height + " " + item.refreshRate + "hz";
            resolutionDropdown.options.Add(option);
        }
        resolutionDropdown.RefreshShownValue();
    }
}
