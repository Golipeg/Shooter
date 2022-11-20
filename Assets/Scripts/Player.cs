using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerAnimationHandler))]
[RequireComponent(typeof(PlayerMovementHandler))]
[RequireComponent(typeof(HealthHandler))]
[RequireComponent(typeof(PlayerRotationHandler))]
public class Player : MonoBehaviour
{
    private PlayerRotationHandler _rotationHandler;
    private PlayerMovementHandler _movementHandler;
    private HealthHandler _healthHandler;
    private PlayerAnimationHandler _animationHandler;

    private void Awake()
    {
        _rotationHandler = GetComponent<PlayerRotationHandler>();
        _movementHandler= GetComponent<PlayerMovementHandler>();
        _healthHandler = GetComponent<HealthHandler>();
        _animationHandler = GetComponent<PlayerAnimationHandler>();
        _healthHandler.Died += OnDied;
    }

    private void OnDestroy()
    {
        _healthHandler.Died -= OnDied;
    }

    private void OnDied()
    {
        _animationHandler.PlayDieAnimation();
        _movementHandler.enabled = false;
        _rotationHandler.enabled = false;
    }
}