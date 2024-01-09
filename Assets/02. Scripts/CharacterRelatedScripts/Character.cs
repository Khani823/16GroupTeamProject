using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour, IDamageable
{
    public CharacterStatsSO stats;
    private CharacterStatsSO currentStats;
    protected TurnManager turnManager;


    protected virtual void Awake()
    {

    }
    protected virtual void Start()
    {
        turnManager = FindObjectOfType<TurnManager>();
    }

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
        turnManager.RemoveFromTurn(gameObject);
        gameObject.SetActive(false);
    }

    public virtual void EnableTurnAction()
    {

    }
    public virtual void DisableTurnAction()
    {

    }

    protected abstract void PerformAction();
}