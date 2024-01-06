using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour, IDamageable
{
    public CharacterStatsSO stats;

    public virtual void TakeDamage(int damage)
    {
        stats.hp -= damage;
        if(stats.hp <= 0)
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
