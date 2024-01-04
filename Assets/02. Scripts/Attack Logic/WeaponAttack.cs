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
	        if(hit.collider != null)
            {
                Debug.Log("맞았습니다! 대ㅔ: " + hit.collider.gameObject.name);
            }
		}
    }
    public abstract void ShowAttackRange(Vector2 direction);

    protected void ClearRangeBoxes()
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
