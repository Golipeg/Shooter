using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerAimController))]
[RequireComponent(typeof(PlayerInputHandler))]
[RequireComponent(typeof(AnimationHandler))]
[RequireComponent(typeof(PlayerMovementHandler))]
[RequireComponent(typeof(HealthHandler))]
[RequireComponent(typeof(PlayerRotationHandler))]
public class Player : MonoBehaviour
{
    private PlayerRotationHandler _rotationHandler;
    private PlayerMovementHandler _movementHandler;
    private HealthHandler _healthHandler;
    private AnimationHandler _animationHandler;
    private PlayerInputHandler _inputHandler;
    private PlayerAimController _aimController;
    [SerializeField] private CameraController _cameraController;


    private void Awake()
    {
        _rotationHandler = GetComponent<PlayerRotationHandler>();
        _movementHandler = GetComponent<PlayerMovementHandler>();
        _healthHandler = GetComponent<HealthHandler>();
        _animationHandler = GetComponent<AnimationHandler>();
        _inputHandler = GetComponent<PlayerInputHandler>();
        _aimController = GetComponent<PlayerAimController>();
        _inputHandler.AimModeChanged += OnAimModeChanged;
        _healthHandler.Died += OnDied;
    }

    private void OnAimModeChanged()
    {
        _aimController.SetAimingState(!_aimController.IsAiming);
        _movementHandler.SetAimingState(_aimController.IsAiming);
        _cameraController.SetAimingMode(_aimController.IsAiming);
    }

    private void OnDestroy()
    {
        if (_healthHandler != null)
        {
            _healthHandler.Died -= OnDied;
        }

        if (_inputHandler != null)
        {
            _inputHandler.AimModeChanged -= OnAimModeChanged;
        }
    }

    private void OnDied()
    {
        _animationHandler.PlayDieAnimation();
    }
}