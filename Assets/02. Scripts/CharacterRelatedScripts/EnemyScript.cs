using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : Character
{
    private EnemyManager enemyManager;
    private GameObject player;
    private WeaponAttack weaponAttack;
    private Vector2 lookDirection;
    private float chaseRange = 5.0f;
    private float attackRange;
    public float distanceToPlayer;
    [SerializeField]
    private bool isUnderAction = false;

    protected override void Start()
    {
        base.Start();
        enemyManager = FindObjectOfType<EnemyManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        weaponAttack = GetComponent<WeaponAttack>();
        attackRange = weaponAttack.range;
    }

    public void SetTurn(bool value)
    {
        isUnderAction = value;

        if (value)
        {
            weaponAttack.enabled = true;
        }
        else
        {
            weaponAttack.enabled = false;
        }
    }
    private void Update()
    {
        if (isUnderAction && player != null)
        {
            PerformAction();
        }
    }

    private void ChasePlayer()
    {
        // �÷��̾� �߰� ���� ����
    }

    protected override void PerformAction()
    {
        distanceToPlayer = Vector2.Distance(player.transform.position, transform.position);

        if (weaponAttack.IsTargetInRange(lookDirection))
        {
            AttackPlayer();
        }
        else if (distanceToPlayer <= chaseRange)
        {
            ChasePlayer();
        }
        else
        {
            RandomMove();
        }
    }

    private void AttackPlayer()
    {
        Vector2 directionToPlayer = player.transform.position - transform.position;
        weaponAttack.Attack(directionToPlayer.normalized);
        Debug.Log("�÷��̾ ������ �޾Ҵ�!");
        turnManager.NextTurn();
    }

    private void RandomMove()
    {
        // ���� �̵� ���� ����
        turnManager.NextTurn();

    }

    protected override void Die()
    {
        enemyManager.RemoveEnemy(this.gameObject);
    }



}
