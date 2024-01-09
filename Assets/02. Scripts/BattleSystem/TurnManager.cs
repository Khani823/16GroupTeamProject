using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public GameObject playerObject;
    public int turnCount = 0;
    public int turnToSpawn = 10;
    private EnemyManager enemyManager;

    private Queue<GameObject> turnQueue = new Queue<GameObject>();
    private GameObject currentlyInAction;

    [SerializeField]
    private GameObject isOnAction;

    void Start()
    {
        enemyManager = GetComponent<EnemyManager>();
        AddToTurn(playerObject);
        currentlyInAction = playerObject;
        isOnAction = playerObject;
        ActivateObject(currentlyInAction);
    }

    public void NextTurn()
    {
        if (turnQueue.Count > 0)
        {
            if (currentlyInAction != null)
            {
                DeactivateObject(currentlyInAction);
            }
            currentlyInAction = turnQueue.Dequeue();
            ActivateObject(currentlyInAction);

            turnQueue.Enqueue(currentlyInAction);
            isOnAction = currentlyInAction;

            turnCount++;
            if (turnCount % turnToSpawn == 0)
            {
                enemyManager.TrySpawning();
            }
        }
    }

    private void ActivateObject(GameObject activeObject)
    {
        var weaponAttack = activeObject.GetComponentInChildren<WeaponAttack>();
        if (weaponAttack != null)
        {
            weaponAttack.enabled = true;
        }
        activeObject.GetComponent<Character>().EnableTurnAction();

        if (activeObject.tag == "Enemy")
        {
            activeObject.GetComponent<EnemyScript>().SetTurn(true);
        }
    }

    private void DeactivateObject(GameObject inactiveObject)
    {
        var weaponAttack = inactiveObject.GetComponentInChildren<WeaponAttack>();
        if (weaponAttack != null)
        {
            weaponAttack.enabled = false;
        }

        inactiveObject.GetComponent<Character>().DisableTurnAction();

        if (inactiveObject.tag == "Enemy")
        {
            inactiveObject.GetComponent<EnemyScript>().SetTurn(false);
        }
    }

    public bool IsCurrentlyInAction(GameObject activeObject)
    {
        return activeObject == currentlyInAction;
    }

    public void AddToTurn(GameObject gameObject)
    {
        turnQueue.Enqueue(gameObject);
    }

    public void RemoveFromTurn(GameObject gameObject)
    {
        var newQueue = new Queue<GameObject>();
        while (turnQueue.Count > 0)
        {
            var obj = turnQueue.Dequeue();
            if (obj != gameObject)
            {
                newQueue.Enqueue(obj);
            }
        }
        turnQueue = newQueue;
    }
}
