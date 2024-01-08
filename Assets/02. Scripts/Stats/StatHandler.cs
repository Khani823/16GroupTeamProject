//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;
//using static UnityEditor.Progress;

//public class StatHandler : MonoBehaviour
//{
//    public int maxHP;
//    public int maxMP;
//    public int curHP;
//    public int curMP;
//    public int baseAtk;
//    public int baseDef;
//    public int baseFoc;
//    public float baseCrit;
//    public float baseAgi;
//    public int modAtk = 0;
//    public int modDef = 0;
//    public int modFoc = 0;
//    public float modCrit = 0;
//    public float modAgi = 0;
//    public TextMeshProUGUI statIndicator;


//    public void Initialize(IStatusData charData)
//    {
//        maxHP = charData.Hp;
//        maxMP = charData.Mp;
//        curHP = maxHP;
//        curMP = maxMP;
//        baseAtk = charData.Atk;
//        baseDef = charData.Def;
//        baseFoc = charData.Foc;
//        baseAgi = charData.Agi;
//        baseCrit = charData.Crit;
//        UpdateStat();
//    }

//    public void UpdateStat()
//    {
//        statIndicator.text = $"{curHP}/{maxHP}\n{curMP}/{maxMP}\n{baseAtk + modAtk} ({baseAtk} + {modAtk})\n{baseDef + modDef} ({baseDef} + {modDef})\n{baseFoc + modFoc} ({baseFoc} + {modFoc})\n{baseCrit + modCrit} %\n{baseAgi + modAgi} %";
//    }

//    public void TakeDamage(int damage)
//    {
//        curHP -= damage;
//        curHP = Mathf.Max(curHP, 0);
//    }

//    public void UseMP(int usedMP)
//    {
//        curMP -= usedMP;
//        curMP = Mathf.Max(curMP, 0);
//    }

//    public void IncreaseStat(ItemSO item)
//    {
//        curHP += item.plusHP;
//        curMP += item.plusMP;
//        modAtk += item.plusAtk;
//        modDef += item.plusDef;
//        modFoc += item.plusFoc;
//        modAgi += item.plusAgi;
//        modCrit += item.plusCrit;
//        UpdateStat();
//    }

//    public void DecreaseStat(ItemSO item)
//    {
//        curHP -= item.plusHP;
//        curMP -= item.plusMP;
//        modAtk -= item.plusAtk;
//        modDef -= item.plusDef;
//        modFoc -= item.plusFoc;
//        modAgi -= item.plusAgi;
//        modCrit -= item.plusCrit;
//        UpdateStat();
//    }

//    public IStatusData GetFinalStats()
//    {
//        return new FinalStats(this);
//    }

//    public PlayerCharacterSO GetCurrentStats()
//    {
//        PlayerCharacterSO currentStats = new PlayerCharacterSO();
//        currentStats.hp = curHP;
//        currentStats.mp = curMP;
//        currentStats.atk = baseAtk + modAtk;
//        currentStats.def = baseDef + modDef;
//        currentStats.foc = baseFoc + modFoc;
//        currentStats.crit = baseCrit + modCrit;
//        currentStats.agi = baseAgi + modAgi;
//        return currentStats;
//    }

//}
