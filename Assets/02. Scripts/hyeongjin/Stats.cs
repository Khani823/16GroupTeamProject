using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats
{


    // ¸â¹ö º¯¼ö
    [SerializeField]
    protected int _level;
    [SerializeField]
    protected int _hp;
    [SerializeField]
    protected int _maxHp;
    [SerializeField]
    protected int _attack;
    [SerializeField]
    protected int _defense;
    [SerializeField]
    protected float _moveSpeed;
    [SerializeField]
    private int BaseValue;

    // ¸â¹ö ÇÁ·ÎÆÛÆ¼
    public int Level { get { return _level; } set { _level = value; } }
    public int Hp { get { return _hp; } set { _hp = value; } }
    public int MaxHp { get { return _maxHp; } set { _maxHp = value; } }
    public int Attack { get { return _attack; } set { _attack = value; } }
    public int Defense { get { return _defense; } set { _defense = value; } }
    public float MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }

    private List<int> modifiers = new List<int>();

    private void Start()
    {
        _level = 1;
        _hp = 100;
        _maxHp = 100;
        _attack = 10;
        _defense = 5;
        _moveSpeed = 5.0f;
    }

    public int GetValue()
    {
        int finalValue = BaseValue;
        modifiers.ForEach(x => finalValue += x);
        return finalValue; 
    }

    public void AddModifier(int modifier)
    {
        if (modifier != 0)
        {
            modifiers.Add(modifier);
        }
    }

    public void RemoveModifier(int modifier)
    {
        if (modifier != 0)
        {
            modifiers.Remove(modifier);
        }
    }

    public void IncreaseStatsForLevelUp()
    {
        // ·¹º§¾÷ ½Ã ½ºÅÈÀ» »ó½Â.
        Hp += 10;
        Attack += 3;
        Defense += 2;
        MoveSpeed += 0.5f;
    }

}
