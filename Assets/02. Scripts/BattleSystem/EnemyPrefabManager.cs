using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrefabManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject GetEnemyPrefab()
    {
        int randomIndex = UnityEngine.Random.Range(0, enemyPrefabs.Length);
        GameObject prefab = enemyPrefabs[randomIndex];
        return prefab;
    }
}
