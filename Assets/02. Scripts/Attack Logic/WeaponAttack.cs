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

    protected virtual void Awake()
    {
        directionToLook = new PlayerController2D();
        directionToLook.Player.Move.performed += OnMovePerformed; // 구독
        directionToLook.Player.Move.canceled += OnMoveCanceled; // 구독 해제
    }

    protected void OnEnable()
    {
        directionToLook.Enable();
    }
    protected void OnDisable()
    {
        directionToLook.Disable();
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
                CharacterStatsSO attackerStat = GetComponentInParent<CharacterStatsSO>();
                CharacterStatsSO defenderStat = hit.collider.GetComponent<CharacterStatsSO>();

                if (defenderStat != null)
                {
                    int damage = DamageCalculation(attackerStat, defenderStat);
                    damageableObject.TakeDamage(damage);
                    Debug.Log("맞았습니다! 대ㅔ: " + hit.collider.gameObject.name);
                }
            }
		}
    }

    protected virtual int DamageCalculation(CharacterStatsSO attackerStat, CharacterStatsSO defenderStat)
    {
        int baseDamage = Mathf.Max(1, attackerStat.atk - defenderStat.def);
        return baseDamage;
    }

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
