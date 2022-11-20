using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private HealthHandler _healthHandler;
    [SerializeField] private EnemyAnimation _enemyAnimation;
    [SerializeField] private float _delaybeforeDestroying;
    private void Start()
    {
        _healthHandler.Died += OnDied;
    }

    private void OnDestroy()
    {
        _healthHandler.Died -= OnDied;
    }

    private void OnDied()
    {
        _enemyAnimation.PlayAnimationDying();
        Destroy(gameObject,3f);
        
    }
}
