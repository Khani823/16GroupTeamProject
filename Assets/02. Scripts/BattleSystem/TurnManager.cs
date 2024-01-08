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
    }

    public void NextTurn()
    {
        if(turnQueue.Count > 0 )
        {
            if(currentlyInAction != null)
            {
                currentlyInAction.GetComponent<Character>().DisableTurnAction();
            }

            currentlyInAction = turnQueue.Dequeue();
            Debug.Log("현재턴 : " + currentlyInAction.name);

            currentlyInAction.GetComponent<Character>().EnableTurnAction();
            isOnAction = currentlyInAction;

            turnQueue.Enqueue(currentlyInAction);

            turnCount++;
            if (turnCount % turnToSpawn == 0)
            {
                enemyManager.TrySpawning();
            }
        }
    }

    private void ActivateObject(GameObject activeObject)
    {
        activeObject.GetComponent<Character>().EnableTurnAction();
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

    }
}
