using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Vector3 = UnityEngine.Vector3;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private HealthHandler _healthHandler;

    [SerializeField] private NavMeshAgent _navMeshAgent;
    
    [SerializeField] 
    private float _delaybeforeDestroying;

    [SerializeField] 
    private float _shootingRange = 5f;

    [SerializeField] private AnimationHandler _animationHandler;
    
    [SerializeField]
    private Transform _target;

    private void Start()
    {
        _healthHandler.Died += OnDied;
    }
    public void Initialize(Transform target)
    {
        _target = target;
        MoveToShootingRange(target);
    }
    private void MoveToShootingRange(Transform target)
    {
        var distanceToTarget = Vector3.Distance(transform.position, target.position);
        var shootingDistance = Mathf.Max(0, distanceToTarget - _shootingRange);
        var directionToTarget = (target.position - transform.position).normalized;
        var destination = transform.position + directionToTarget * shootingDistance;
        _navMeshAgent.destination = destination;
    }

    private void Update()
    {
        MoveToShootingRange(_target);
        bool isWalking = _navMeshAgent.remainingDistance > _navMeshAgent.stoppingDistance;
        _animationHandler.SetWalkMode(isWalking);
        if (!isWalking)
        {
            TryShoot();
        }
    }

    private void OnDestroy()
    {
        _healthHandler.Died -= OnDied;
    }

    private void TryShoot()
    {
        Debug.Log("Shooting");
    }

    private void OnDied()
    {
        _animationHandler.PlayDieAnimation();
        Destroy(gameObject, _delaybeforeDestroying);
    }
}