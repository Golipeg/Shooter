using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementHandler : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _speed;
    private Transform _transform;
    [SerializeField] HealthHandler _healthHandler;

    private void Awake()
    {
        _transform = _player.transform;
    }

    private void Update()
    {
        if (_healthHandler.IsAlive)
        {
            var playerPosition = _transform.position;
            var target = new Vector3(playerPosition.x, playerPosition.y, playerPosition.z);
            transform.LookAt(target);
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * _speed);
        }
    }
}
