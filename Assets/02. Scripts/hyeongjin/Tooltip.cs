using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEditor.Progress;

public class Tooltip : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _titleText;   // ������ �̸� �ؽ�Ʈ

    [SerializeField]
    private TMP_Text _contentText; // ������ ���� �ؽ�Ʈ
    // Start is called before the first frame update

    public void SetupTooltip(string name, string description)
    {
        _titleText.text = name;
        _contentText.text = description;
    }
}
