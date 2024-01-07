using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class WeaponAttack : MonoBehaviour
{
    public float range;
    public LayerMask targetlayer;
    public Vector2 lookDirection;
    public GameObject rangeBox;
    protected List<GameObject> rangeBoxes = new List<GameObject>();
    private PlayerController2D directionToLook;
    private PlayerController2D attack;

    protected virtual void Awake()
    {
        directionToLook = new PlayerController2D();
        attack = new PlayerController2D();
        directionToLook.Player.Move.performed += OnMovePerformed; // 구독
        directionToLook.Player.Move.canceled += OnMoveCanceled; // 구독 해제
        attack.Player.Attack.performed += OnAttackPerformed;
        attack.Player.Attack.canceled += OnAttackCanceled;
    }

    private void OnAttackPerformed(InputAction.CallbackContext obj)
    {
        Debug.Log("공격시작");
        Attack(lookDirection);
    }

    private void OnAttackCanceled(InputAction.CallbackContext obj)
    { }

    protected void OnEnable()
    {
        directionToLook.Enable();
        attack.Enable();
    }
    protected void OnDisable()
    {
        directionToLook.Disable();
        attack.Disable();
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();

        if (Mathf.Abs(moveInput.x) > Mathf.Abs(moveInput.y))
        {
            moveInput = new Vector2(moveInput.x, 0);
        }
        else
        {
            moveInput = new Vector2(0, moveInput.y);
        }
        UpdateDirection(moveInput.normalized);
    }

    private void OnMoveCanceled(InputAction.CallbackContext context) { }

    protected void UpdateDirection(Vector2 newDirection)
    {
        ClearRangeBoxes();
        lookDirection = newDirection;
        ShowAttackRange(lookDirection);
    }

    public virtual void Attack(Vector2 direction)
    {
        Debug.Log("SpaceBar");
        CheckAttackRange(direction);
        ClearRangeBoxes();
    }

    protected void CheckAttackRange(Vector2 direction)
    {
        Vector2 position = transform.position;
        RaycastHit2D[] hits = Physics2D.RaycastAll(position, direction, range, targetlayer);  
        foreach (RaycastHit2D hit in hits)
        {
            IDamageable damageableObject = hit.collider.GetComponent<IDamageable>();
	        if(damageableObject != null)
            {
                Character attackerStat = GetComponentInParent<Character>();
                Character defenderStat = hit.collider.GetComponent<Character>();

                if (defenderStat != null)
                {
                    Vector2 targetPosition = hit.collider.transform.position;
                    int damage = CalculateFinalDamage(attackerStat.stats, defenderStat.stats, direction, targetPosition);
                    damageableObject.TakeDamage(damage);
                    Debug.Log($"맞은 대상: {hit.collider.gameObject.name}, 받은 대미지: {damage}");
                }
            }
		}
    }

    protected int DamageCalculation(CharacterStatsSO attackerStat, CharacterStatsSO defenderStat)
    {
        int baseDamage = Mathf.Max(1, attackerStat.atk - defenderStat.def);
        return baseDamage;
    }

    protected bool IsFront(Vector2 targetPosition)
    {
        Vector2 attackerDirection = lookDirection.normalized;
        Vector2 toTarget = (targetPosition - (Vector2)transform.position).normalized;
        float angle = Vector2.Angle(attackerDirection, toTarget);
        return angle <= 45.0f;
    }

    protected abstract int CalculateFinalDamage(CharacterStatsSO attackerStats, CharacterStatsSO defenderStats, Vector2 attackDirection, Vector2 targetPosition);

    public abstract void ShowAttackRange(Vector2 direction);

    public void ClearRangeBoxes()
    {
        foreach (var box in rangeBoxes)
        {
            Destroy(box);
        }
        rangeBoxes.Clear();
    }
    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        DrawAttackRay(lookDirection);
    }

    protected void DrawAttackRay(Vector2 direction)
    {
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + direction * range);
    }
}
