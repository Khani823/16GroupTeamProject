using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStat : Stats
{    //PlayerStat > Stat을 상속 받음. 플레이어의 스탯.

    [SerializeField]
    protected int _exp;
    [SerializeField]
    protected int _gold;
    [SerializeField]
    protected int _level;
    public Stats Stats { get; private set; }
    private ExperienceTable experienceTable;


    public int Exp { get { return _exp; } set { _exp = value; } }
    public int Gold { get { return _gold; } set { _gold = value; } }

    private void Start()
    {
        _level = 1;
        _hp = 100;
        _maxHp = 100;
        _attack = 10;
        _defense = 5;
        _moveSpeed = 5.0f;
        _exp = 0;
        _gold = 0;
    }
    public PlayerStat(int level, int exp, Stats stats)
    {
        Level = level;
        Exp = exp;
        Stats = stats;
        experienceTable = new ExperienceTable();
    }

    public void GainExperience(int amount)
    {
        Exp += amount;
        CheckForLevelUp();
    }

    private void CheckForLevelUp()
    {
        int requiredExperience = experienceTable.GetExperienceForLevel(Level + 1);
        if (Exp >= requiredExperience)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        Level++;
        Stats.IncreaseStatsForLevelUp();
    }
}
