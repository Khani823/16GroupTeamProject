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
    void Start()
    {
        enemyManager = GetComponent<EnemyManager>();
        AddToTurn(playerObject);
    }

    public void NextTurn()
    {
        if(turnQueue.Count > 0 )
        {
            GameObject currentTurn = turnQueue.Dequeue();
            Debug.Log("«ˆ¿Á≈œ: " + currentTurn.name);
            turnQueue.Enqueue(currentTurn);

            turnCount++;
                if (turnCount % turnToSpawn == 0)
            {
                enemyManager.TrySpawning();
            }
        }
    }

    public void AddToTurn(GameObject gameObject)
    {
        turnQueue.Enqueue(gameObject);
    }

    public void RemoveFromTurn(GameObject gameObject)
    {

    }
}
