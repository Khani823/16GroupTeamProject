using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public int poolSize;
    //public GameObject enemyToSpawn;

    private EnemyPrefabManager enemyPrefabManager;
    private Queue<GameObject> pool = new Queue<GameObject>();
    private int currentPoolSize = 0;


    private void Start()
    {
        enemyPrefabManager = GetComponent<EnemyPrefabManager>();
        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemyPrefab = enemyPrefabManager.GetEnemyPrefab();
            GameObject obj = Instantiate(enemyPrefab, transform);
            obj.SetActive(false); 
            pool.Enqueue(obj);
        }
    }
    public GameObject GetObject()
    {
        if (currentPoolSize >= poolSize)
        {
            return null;
        }

        GameObject obj;
        if(pool.Count > 0)
        {
            obj = pool.Dequeue();
        }
        else
        {
            GameObject enemyPrefab = enemyPrefabManager.GetEnemyPrefab();
            if (enemyPrefab == null)
            {
                return null;
            }
            obj = Instantiate(enemyPrefab) ;
            currentPoolSize++;
        }
        obj.SetActive(true);
        return obj;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        pool.Enqueue(obj);
        currentPoolSize--;
    }
}
