using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounterUI : MonoBehaviour
{
    [SerializeField] private RawImage _enemyImage;
    private List<RawImage> _enemiesImage = new List<RawImage>();
    [SerializeField] private HealthHandler _healthHandler;

    private void Start()
    {
        _healthHandler.Died += UpdateEnemiesCounterUI;
    }

    public void Initialize(int enemiesQuantity)
    {
        for (int i = 0; i < enemiesQuantity; i++)
        {
            RawImage _image = Instantiate(_enemyImage, transform);
            _enemiesImage.Add(_image);
        }
    }

    public void UpdateEnemiesCounterUI()
    {
        if (_enemiesImage.Count > 0)
        {
            Destroy(_enemiesImage[_enemiesImage.Count-1]);
            _enemiesImage.RemoveAt(_enemiesImage.Count-1);
        }
            
    }

    private void OnDestroy()
    {
        _healthHandler.Died -= UpdateEnemiesCounterUI;
    }
}