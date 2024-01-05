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

    // 레벨, 경험치, 마나 설정
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

    // 플레이어가 공격당할 때 호출되는 메서드
    public void TakeDamage(float damageAmount)
    {
        curHp -= damageAmount;
        UpdateHpBar();
        
        if (curHp <= 0)
        {
            Debug.Log("죽음");
        }
    }

    // 스킬을 사용할 때 호출되는 메서드
    public void UseSkill(float mpCost)
    {
        if (curMP >= mpCost)
        {
            curMP -= mpCost;
            UpdateMpBar();
            
            Debug.Log("스킬 사용!");
        }
        else
        {
            Debug.Log("MP 부족");
        }
    }

    // 킬이 일어났을 때 호출되는 메서드
    public void GainExperience(int xp)
    {
        exp += xp;

        // 레벨 업이 가능하면 업!!        
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

        // 레벨업 후 경험치량 증가
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
        // MpBar 업데이트
        float mpPercentage = curMP / maxMP;
        mpBar.GetComponent<Image>().fillAmount = mpPercentage;
    }


    void UpdateHpBar()
    {
        // HP바 업데이트
        float hpPercentage = curHp / maxHp;
        hpBar.GetComponent<Image>().fillAmount = hpPercentage;
    }
    void UpdateExpBar()
    {
        // 경험치 바 UI 업데이트
        float fillAmount = (float)exp / maxexp;
        xpBar.GetComponent<Image>().fillAmount = fillAmount;
    }
}
