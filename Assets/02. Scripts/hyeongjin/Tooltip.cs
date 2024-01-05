using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEditor.Progress;

public class Tooltip : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _titleText;   // 아이템 이름 텍스트

    [SerializeField]
    private TMP_Text _contentText; // 아이템 설명 텍스트
    // Start is called before the first frame update

    public void SetupTooltip(string name, string description)
    {
        _titleText.text = name;
        _contentText.text = description;
    }
}
