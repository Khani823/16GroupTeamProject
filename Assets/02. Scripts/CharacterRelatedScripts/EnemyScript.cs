using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : Character
{
    private EnemyManager enemyManager;

    private void Start()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
    }
    protected override void Die()
    {
        enemyManager.RemoveEnemy(this.gameObject);
    }
}
