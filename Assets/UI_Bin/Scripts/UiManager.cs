using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class UiManager : MonoBehaviour
{
    public Text levelText;
    public Text EXPText;
    public Text HPText;
    public Text MPText;
    public Text ATTText;
    public Text DEFText;
    public Text GoldText;


    [SerializeField]
    private Slider hpBar;
    [SerializeField]
    private Slider mpBar;
    [SerializeField]
    private Slider expBar;

    private float level = 1;
    private float exp = 0;
    private float HP = 100;
    private float MP = 100;
    private float Att = 10;
    private float Def = 10;
    private float MaxHP = 100;
    private float MaxMP = 100;
    private float Maxexp = 100;
    private float Gold = 50;


    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
            UseSkill(10);
            GainExperience(10);
        }
    }

    private void UpdateUI()
    {
        hpBar.value = HP / MaxHP;
        mpBar.value = MP / MaxMP;
        expBar.value = exp / Maxexp;

        HPText.text = HP.ToString() + " / " + MaxHP.ToString();
        MPText.text = MP.ToString() + " / " + MaxMP.ToString();
        EXPText.text = exp.ToString() + " / " + Maxexp.ToString();
        ATTText.text = Att.ToString();
        DEFText.text = Def.ToString();
        GoldText.text = Gold.ToString();
        levelText.text = "Lv: " + level.ToString();
    }

    // �÷��̾ ���ݴ��� �� ȣ��Ǵ� �޼���
    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        HP = Mathf.Max(HP, 0);
        UpdateHpBar();

        if (HP <= 0)
        {
            Debug.Log("����");
        }
    }

    // ��ų�� ����� �� ȣ��Ǵ� �޼���
    public void UseSkill(int mpCost)
    {
        if (MP >= mpCost)
        {
            MP -= mpCost;
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
        Gold += 10;

        // ���� ���� �����ϸ� ��!!        
        if (exp >= Maxexp)
        {
            LevelUp();
        }

        UpdateExpBar();
    }

    void LevelUp()
    {
        level++;
        exp = 0;

        // ������ �� ���� ����
        Maxexp += 100;
        MaxHP += 10;
        MaxMP += 10;
        Att += 10;
        Def += 10;

        UpdateUI();
    }

    void UpdateMpBar()
    {
        // MpBar ������Ʈ
        float mpPercentage = MP / MaxMP;
        mpBar.value = Mathf.Lerp(mpBar.value, MP / MaxMP, Time.deltaTime * 10);
        UpdateUI();
    }


    void UpdateHpBar()
    {
        // HP�� ������Ʈ
        float hpPercentage = HP / MaxHP;
        hpBar.value = Mathf.Lerp(hpBar.value, HP / MaxHP, Time.deltaTime * 10);
        UpdateUI();
    }
    void UpdateExpBar()
    {
        // ����ġ �� UI ������Ʈ
        float fillAmount = exp / Maxexp;
        expBar.value = Mathf.Lerp(expBar.value, exp / Maxexp, Time.deltaTime * 10);
        UpdateUI();
    }

    int CalculateAtt()
    {
        return (int)level * 2;
    }

    int CalculateDef()
    {
        return (int)level * 2;
    }
}
