using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    private bool isMoving;
    private Vector3 origPos, targetPos;
    private float timeToMove = 0.2f;
    private float collisionCheckDistance = 1.0f;
    private WeaponAttack weaponAttack;
    private int layerMask;


    private void Awake()
    {
        // 현재 게임 오브젝트의 레이어를 제외하는 레이어마스크 생성
        layerMask = 1 << gameObject.layer;
        layerMask = ~layerMask; // 해당 레이어를 제외
    }
    
    public void FindWeapon()
    {
        weaponAttack = GetComponentInChildren<WeaponAttack>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && !isMoving)
            TryMove(Vector2.up);
        if (Input.GetKey(KeyCode.A) && !isMoving)
            TryMove(Vector2.left);
        if (Input.GetKey(KeyCode.S) && !isMoving)
            TryMove(Vector2.down);
        if (Input.GetKey(KeyCode.D) && !isMoving)
            TryMove(Vector2.right);
    }

    private void TryMove(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, collisionCheckDistance, layerMask);
        Debug.Log($"Trying to move in direction: {direction}, Hit: {hit.collider}");
        if (hit.collider == null)
        {
            StartCoroutine(MovePlayer(direction));
	    }
    }
    
    private IEnumerator MovePlayer(Vector3 direction)
    {
        Debug.Log("Starting MovePlayer Coroutine");
        isMoving = true;

        float elapsedTime = 0;

        origPos = transform.position;
        targetPos = origPos + direction;

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
        if (weaponAttack == null)
            FindWeapon();
        if (weaponAttack != null)
            weaponAttack.UpdateDirection(direction);



        isMoving = false;
        Debug.Log("Ending MovePlayer Coroutine");
    }
}
