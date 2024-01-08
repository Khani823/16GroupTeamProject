using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpStation : MonoBehaviour
{
    public GameObject battleMap01;
    public GameObject battleMap02;
    public Transform spawnPoint;
    public float interactionDistance = 1.0f;

    void Start()
    {
        battleMap01.SetActive(true);
        battleMap02.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && IsPlayerInRange())
        {
            SwitchToBattleMap02();
        }

        if (Input.GetMouseButtonDown(0))
        {
            CheckMouseClick();
        }
    }

    private void CheckMouseClick()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null && hit.collider.gameObject == gameObject && IsPlayerInRange())
        {
            SwitchToBattleMap02();
        }
    }

    private bool IsPlayerInRange()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float distance = Vector2.Distance(player.transform.position, transform.position);
            return distance <= interactionDistance;
        }
        return false;
    }

    private void SwitchToBattleMap02()
    {
        battleMap01.SetActive(false);
        battleMap02.SetActive(true);
        MovePlayerToSpawnPoint();
    }

    private void MovePlayerToSpawnPoint()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null && spawnPoint != null)
        {
            player.transform.position = spawnPoint.position;
        }
    }
}
