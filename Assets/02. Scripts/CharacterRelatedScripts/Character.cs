using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour, IDamageable
{
    public CharacterStatsSO stats;
    private CharacterStatsSO currentStats;

    private void OnEnable()
    {
        currentStats = Instantiate(stats);
    }
    public virtual void TakeDamage(int damage)
    {
        currentStats.hp -= damage;
        if(currentStats.hp <= 0)
        {
            Die();
        }    
    }

    public void TakeHeal(int heal)
    {
        throw new NotImplementedException();
    }

    protected virtual void Die()
    {
        throw new NotImplementedException();
    }
}
