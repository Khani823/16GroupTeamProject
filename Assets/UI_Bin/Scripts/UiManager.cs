using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text levelText;
    public Text HPText;
    public Text MPText;
    public Text EXPText;
    public GameObject xpBar;
    public GameObject hpBar;
    public GameObject mpBar;

    // ����, ����ġ, ���� ����
    int level = 1;
    int HP = 100;
    int MP = 100;    
    int exp = 0;
    int maxexp = 100;
    
    private float maxHp = 100f;
    private float curHp;
    public float maxMP = 100f;
    private float curMP;

    float imsi;

    void Start()
    {
        curHp = maxHp;
        curMP = maxMP;
        UpdateText();
    }

    void Update()
    {

    }

    // �÷��̾ ���ݴ��� �� ȣ��Ǵ� �޼���
    public void TakeDamage(float damageAmount)
    {
        curHp -= damageAmount;
        UpdateHpBar();
        
        if (curHp <= 0)
        {
            Debug.Log("����");
        }
    }

    // ��ų�� ����� �� ȣ��Ǵ� �޼���
    public void UseSkill(float mpCost)
    {
        if (curMP >= mpCost)
        {
            curMP -= mpCost;
            UpdateMpBar();
            
            Debug.Log("��ų ���!");
        }
        else
        {
            Debug.Log("MP ����");
        }
    }

    // ų�� �Ͼ�� �� ȣ��Ǵ� �޼���
    public void GainExperience(int xp)
    {
        exp += xp;

        // ���� ���� �����ϸ� ��!!        
        if (exp >= maxexp)
        {
            LevelUp();
        }

        UpdateExpBar();
    }

    void LevelUp()
    {
        level++;
        exp = 0;

        // ������ �� ����ġ�� ����
        maxexp += 10;
        HP += 10;
        MP += 10;

        UpdateExpBar();
        UpdateText();
    }

    void UpdateText()
    {
        levelText.text = "Lv: " + level.ToString();
        HPText.text = HP.ToString();
        MPText.text = MP.ToString();
        EXPText.text = exp.ToString();
    }

    void UpdateMpBar()
    {
        // MpBar ������Ʈ
        float mpPercentage = curMP / maxMP;
        mpBar.GetComponent<Image>().fillAmount = mpPercentage;
    }


    void UpdateHpBar()
    {
        // HP�� ������Ʈ
        float hpPercentage = curHp / maxHp;
        hpBar.GetComponent<Image>().fillAmount = hpPercentage;
    }
    void UpdateExpBar()
    {
        // ����ġ �� UI ������Ʈ
        float fillAmount = (float)exp / maxexp;
        xpBar.GetComponent<Image>().fillAmount = fillAmount;
    }
}
