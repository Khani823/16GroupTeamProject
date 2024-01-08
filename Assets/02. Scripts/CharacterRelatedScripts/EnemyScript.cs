using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : Character
{
    private EnemyManager enemyManager;

    protected override void Start()
    {
        base.Start();
        enemyManager = FindObjectOfType<EnemyManager>();
    }
    protected override void Die()
    {
        enemyManager.RemoveEnemy(this.gameObject);
    }

    protected override void PerformAction()
    {
        throw new System.NotImplementedException();
    }
}
