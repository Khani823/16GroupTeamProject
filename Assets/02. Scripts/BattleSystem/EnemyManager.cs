using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public ObjectPool enemyPool;
    public Transform[] spawnPoints;
    public float spawnRadius = 1.0f;
    public LayerMask enemyLayer;
    public int initialEnemy = 7;

    private TurnManager turnManager;

    private void Start()
    {
        turnManager = GetComponent<TurnManager>();
        List<Transform> availablePoints = new List<Transform>(spawnPoints);
        Shuffle(availablePoints);

        HashSet<Transform> usedPoints = new HashSet<Transform>();

        for (int i = 0; i<initialEnemy && i <availablePoints.Count; i++)
        {
            if(!usedPoints.Contains(availablePoints[i]))
            { 
                SpawnEnemyAtPosition(availablePoints[i].position);
                usedPoints.Add(availablePoints[i]);
            }
        }
    }

    private void Shuffle (List<Transform> list)
    {
        for(int i = 0; i< list.Count; i++)
        {
            Transform temp = list[i];
            int randomIndex = UnityEngine.Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    public void TrySpawning()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            if (!IsExisting(spawnPoint.position))
            {
                SpawnEnemyAtPosition(spawnPoint.position);
                return;
            }
        }
    }

    private bool IsExisting(Vector2 position)
    {
        Collider2D hitCollider = Physics2D.OverlapCircle(position, spawnRadius, enemyLayer);
        return hitCollider != null;
    }

    private void SpawnEnemyAtPosition(Vector2 position)
    {
        GameObject enemy = enemyPool.GetObject();
        if (enemy != null)
        {
            enemy.transform.position = position;
            turnManager.AddToTurn(enemy);
            Debug.Log("积己困摹 :" + position + ", 积己茄巴 :" + enemy.name);
        }
    }


    public void RemoveEnemy(GameObject enemy)
    {
        turnManager.RemoveFromTurn(enemy);
        enemyPool.ReturnObject(enemy);
    }
}
