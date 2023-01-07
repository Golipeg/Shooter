using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] 
    private Enemy _enemyPrefab;
    
    [SerializeField]
    private Transform _spawnPoint;
    
    [SerializeField] 
    private float _radius = 5f;

    //[SerializeField]
    //private int _enemiesCount = 5;

    public void Initialize(Transform enemiesTarget,int enemiesQuantity)
    {
        for (int i = 0; i < enemiesQuantity; i++)
        {
            var enemy = Instantiate(_enemyPrefab);
            var randomPosition = _spawnPoint.transform.position + Random.insideUnitSphere;
            randomPosition.y = 0;
            enemy.transform.position = randomPosition;
            enemy.Initialize(enemiesTarget);
        }
    }
}