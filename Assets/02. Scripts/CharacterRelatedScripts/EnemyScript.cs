using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : Character
{
    private EnemyManager enemyManager;
    private GameObject player;
    private WeaponAttack weaponAttack;
    private float chaseRange = 5.0f; // �߰� ����

    protected override void Start()
    {
        base.Start();
        enemyManager = FindObjectOfType<EnemyManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        weaponAttack = GetComponent<WeaponAttack>();
    }

    private void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

            if (distanceToPlayer <= chaseRange)
            {
                ChasePlayer();
            }
            else if (IsPlayerInRange())
            {
                AttackPlayer();
            }
            else
            {
                turnManager.NextTurn();
            }
        }
    }

    private bool IsPlayerInRange()
    {
        Vector2 directionToPlayer = player.transform.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer.normalized, weaponAttack.range, weaponAttack.targetlayer);
        return hit.collider != null && hit.collider.gameObject == player;
    }

    private void ChasePlayer()
    {
        // �÷��̾� �߰� ���� ����
    }

    private void AttackPlayer()
    {
        Vector2 directionToPlayer = player.transform.position - transform.position;
        weaponAttack.SetLookDirection(directionToPlayer.normalized);
        weaponAttack.Attack(directionToPlayer.normalized);
        Debug.Log("�÷��̾ ������ �޾Ҵ�!");
    }

    protected override void PerformAction()
    {
        throw new System.NotImplementedException();
    }

    protected override void Die()
    {
        enemyManager.RemoveEnemy(this.gameObject);
    }
}
